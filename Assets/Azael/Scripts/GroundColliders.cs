using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliders : MonoBehaviour
{
    //Script para colocar los colliders del suelo cuando se pasa a vista 2D
    //Se añade a los bloques de suelo que tienen 2 colliders
   
    void Update()
    {
        if(Camera_Transition.ortho)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
