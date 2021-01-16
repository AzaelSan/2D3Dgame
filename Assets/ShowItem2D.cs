using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowItem2D : MonoBehaviour
{
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera_Transition.ortho)
        {
            render.enabled = true;
            Debug.Log(gameObject);
        }
        else
        {
            render.enabled = false;
        }
    }
}
