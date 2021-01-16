using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WinMenu : MonoBehaviour
{
    public GameObject winUI;
    public GameObject UI;
    public Button mainmenuBtn;

    private void Awake()
    {
        //loader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        winUI.SetActive(false);
    }

    public void Update()
    {
        if (GameManager.instance.win)
        {
            UI.SetActive(false);
            winUI.SetActive(true);
        }
    }

    private void OnEnable()
    {
        GameManager.isPaused = true;
    }

    private void OnDisable()
    {
        GameManager.isPaused = false;
    }
}
