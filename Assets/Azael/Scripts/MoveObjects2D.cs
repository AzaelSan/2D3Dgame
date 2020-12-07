using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects2D : MonoBehaviour
{
    //Mover los objetos cuando la camara cambia a 2D

    Vector3 originalPosition;//Para guardar la posicion 3D de objetos estaticos
    float posX;//Para guardar la posicion en X del jugador
    public GrabPlayer plat;

    void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (Camera_Transition.ortho)
        {
            if (gameObject.CompareTag("Player") || gameObject.CompareTag("Enemy"))
            {
                transform.position = new Vector3(4.0f, transform.position.y, transform.position.z); //Mover al jugador
            }
            else
            {
                transform.position = new Vector3(4.0f, originalPosition.y, originalPosition.z);
            }
        }

        if ((Input.GetButtonDown("Right Bumper") || Input.GetKeyDown(KeyCode.R)))
        {
            if (!Camera_Transition.ortho)
            {
                posX = transform.position.x;
            }
            else
            {
                if (plat != null)
                {
                    if (plat.movingPlat)
                    {
                        posX = plat.pos.x;
                        print(posX);
                    }
                }
                if (gameObject.CompareTag("Player") || gameObject.CompareTag("Enemy"))
                {
                    transform.position = new Vector3(posX, transform.position.y, transform.position.z); //Mover al jugador
                }
                else
                {

                    transform.position = originalPosition;
                }

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlat"))
        {
            plat = collision.gameObject.GetComponent<GrabPlayer>();
        }
    }
}
