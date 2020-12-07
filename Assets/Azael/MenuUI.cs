using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject cont;
    public Button ng;
    public Button con;

    void Start()
    {
        if(cont.activeSelf)
        {
            con.Select();
        }
        else
        {
            ng.Select();
        }
    }

    void Update()
    {


    }
}
