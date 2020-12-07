using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Translucid : MonoBehaviour
{
    //Hacer transparentes los objetos que esten cerca de la camara para que puedas ver atraves de ellos

    GameObject player; //Jugador, para saber su posicion y emitir un rayo
    public LayerMask objects; //La capa de los objetos que pueden hacerse transparentes
    Color opacity; //Material con transparencia
    Color originalColor; //Guardar su color original
    MeshRenderer translucidObject; //Guardar objeto que golpea el rayo
    bool saved = false; //Bool para saber si el color original ya fue guardado

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 dir = player.transform.position - transform.position; //Direccion de la camara al jugador

        Debug.DrawRay(transform.position, dir, Color.green);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, dir, out hit, 10.0f, objects))
        {
            translucidObject = hit.collider.gameObject.GetComponent<MeshRenderer>();
            if(!saved)
            {
                originalColor = translucidObject.material.color;
                saved = true;
            }
            opacity = new Color(originalColor.r, originalColor.g, originalColor.b, 0.3f);
            translucidObject.material.color = opacity;
        }
        else
        {
            
            if(translucidObject != null)
            {
                translucidObject.material.color = originalColor;
                saved = false;
            }
        }
    }
}
