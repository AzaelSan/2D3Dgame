using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliseo : MonoBehaviour
{
    public Camera_Transition cam;
    public BoxCollider trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.perspective == false)
        {
            trigger.isTrigger = false;
        }
        else
        {
            trigger.isTrigger = true;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.canRotate = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cam.canRotate = true;
        }
    }
}
