using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Transition : MonoBehaviour
{
    //Mecánica de girar la camara para cambiar de perspectiva, con un contador que cuando termina regresa automaticamente de 2D a 3D y pausa el tiempo mientras se ejecuta la transicion

    //Sprites de posicion de camara
    public Image cam_img;
    public Sprite izq, der, frente, atras;


    public static bool ortho = false; //Booleano para saber si la camara esta en modo ortografico
    public bool perspective = true; //Booleano para saber si la cámara esta en 3D o 2D
    public bool InTransition = false; //Booleano para saber si la cámara esta en transición
    public static bool inverse = false;
    public bool canRotate = true;

    Camera cam; //Referencia a la cámara
    GameObject pos3DCamera; //Gameobject que esta en la posicion de la camara en 3D
    GameObject pos2DCamera; //Gameobject que esta en la posicion de la camara en 2D
    GameObject pos3DInverseCamera;
    Rigidbody player;

    public float transitionTime; //Tiempo que tarda en transicion
    public float returnTimer; //Tiempo en regresar de 2D a 3D
    float actualVel;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //Obtener el componente cámara
        pos3DCamera = GameObject.FindGameObjectWithTag("3DCamPosition"); //EmptyObject para la posicion de la camara en 3D
        pos2DCamera = GameObject.FindGameObjectWithTag("2DCamPosition"); //EmptyObject para la posicion de la camara en 2D
        pos3DInverseCamera = GameObject.FindGameObjectWithTag("3DInverseCamPosition"); //EmptyObject para la posicion de la camara en 2D
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>(); //Rigibody del jugador
        actualVel = player.gameObject.GetComponent<Movement>().movementSpeed;
        cam_img.sprite = frente;
    }

    void LateUpdate()
    {
        //Activar cambio si no esta en transición----------------------
        if((Input.GetButtonDown("Right Bumper") || Input.GetKeyDown(KeyCode.R)) && !InTransition && canRotate)
        {
            Transition();
        }
        //-------------------------------------------------------------
        if ((Input.GetKeyDown(KeyCode.E)) && !InTransition && perspective)
        {
            Transition180();
        }
    }

    //Función para el movimiento y rotación de la cámara
    public void Transition()
    {
        player.isKinematic = true;
        player.gameObject.GetComponent<Movement>().movementSpeed = 0;

        if (perspective && !inverse) //Cambiar a "2D"
        {
            cam_img.sprite = der;

            InTransition = true;
            perspective = false;
            LeanTween.rotate(gameObject, new Vector3(0.0f, -90.0f, 0.0f), transitionTime).setOnComplete(ChangeBool);
            LeanTween.move(cam.gameObject, pos2DCamera.transform.position, transitionTime);
        }
        else if (perspective && inverse)
        {
            cam_img.sprite = der;

            InTransition = true;
            perspective = false;
            LeanTween.rotate(gameObject, new Vector3(0.0f, -90.0f, 0.0f), transitionTime).setOnComplete(ChangeBool);
            LeanTween.move(cam.gameObject, pos2DCamera.transform.position, transitionTime);
        }
        else if (!perspective && inverse)
        {
            cam_img.sprite = atras;

            ortho = false;
            InTransition = true;
            perspective = true;
            cam.orthographic = false;
            //StopAllCoroutines();
            LeanTween.rotate(gameObject, new Vector3(0.0f, 180.0f, 0.0f), transitionTime).setOnComplete(ChangeBool);
            LeanTween.move(cam.gameObject, pos3DInverseCamera.transform.position, transitionTime);
        }
        else //Cambiar a "3D"
        {
            cam_img.sprite = frente;

            ortho = false;
            InTransition = true;
            perspective = true;
            cam.orthographic = false;
            //StopAllCoroutines();
            LeanTween.rotate(gameObject, new Vector3(0.0f, 0.0f, 0.0f), transitionTime).setOnComplete(ChangeBool);
            LeanTween.move(cam.gameObject, pos3DCamera.transform.position, transitionTime);
        }
    }

    public void Transition180()
    {
        player.isKinematic = true;
        player.gameObject.GetComponent<Movement>().movementSpeed = 0;

        if (!inverse) //Cambiar a "2D"
        {
            cam_img.sprite = atras;

            InTransition = true;
            LeanTween.rotate(gameObject, new Vector3(0.0f, -90.0f, 0.0f), 0.25f).setOnComplete(aTransition180);
            LeanTween.move(cam.gameObject, pos2DCamera.transform.position, 0.25f);
            inverse = true;
        }
        else
        {
            cam_img.sprite = frente;

            InTransition = true;
            LeanTween.rotate(gameObject, new Vector3(0.0f, -90.0f, 0.0f), 0.25f).setOnComplete(aTransition180);
            LeanTween.move(cam.gameObject, pos2DCamera.transform.position, 0.25f);
            inverse = false;
        }

    }

    void aTransition180()
    {
        if (inverse)
        {
            LeanTween.rotate(gameObject, new Vector3(0.0f, 180.0f, 0.0f), 0.25f).setOnComplete(ChangeBool);
            LeanTween.move(cam.gameObject, pos3DInverseCamera.transform.position, 0.25f);
        }
        else
        {
            LeanTween.rotate(gameObject, new Vector3(0.0f, 0.0f, 0.0f), 0.25f).setOnComplete(ChangeBool);
            LeanTween.move(cam.gameObject, pos3DCamera.transform.position, 0.25f);
        }

    }



    //Cambiar booleano de transición al terminar el movimiento y poder volver a activarlo
    void ChangeBool()
    {
        InTransition = false;

        player.gameObject.GetComponent<Movement>().movementSpeed = actualVel;
        player.isKinematic = false;

        if (!perspective)
        {
            cam.orthographic = true; //Cambiar cámara a proyección ortografica
            ortho = true;
            //StartCoroutine(Counter());
        }
    }

    //Contador para cambiar de 2D a 3D despues de un tiempo determinado
    IEnumerator Counter()
    {
        yield return new WaitForSeconds(returnTimer);

        Transition();
    }
}
