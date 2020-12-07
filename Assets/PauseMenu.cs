using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject options;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    private void LateUpdate()
    {
        if(Input.GetButtonDown("Start Button") || Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuUI.SetActive(GameManager.isPaused);
        }
    }

    public void Resume()
    {
        GameManager.Resume();
        PauseMenuUI.SetActive(GameManager.isPaused);
    }

    public void OpenOptions()
    {
        PauseMenuUI.SetActive(false);
        options.SetActive(true);
    }
}
