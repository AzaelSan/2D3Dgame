using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOn2D : MonoBehaviour
{
    MeshRenderer mesh;
    BoxCollider collider;
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Camera_Transition.ortho)
        {
            mesh.enabled = false;
            collider.enabled = false;
        }
        else
        {
            mesh.enabled = true;
            collider.enabled = true;
        }
    }
}
