using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject options;
    public GameObject checkpoint;
    public LevelLoader loader;

    private void Start()
    {
        loader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        PauseMenuUI.SetActive(false);
    }

    private void LateUpdate()
    {
        if(Input.GetButtonDown("Start Button") || Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuUI.SetActive(GameManager.isPaused);
            if(options.active == true)
            {
                options.SetActive(false);
            }
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

    public void loadCheckpoint()
    {
        GameManager.Resume();
        loader.Continue();
    }

    public void menu()
    {
        loader.LoadMainMenu();
    }
}
