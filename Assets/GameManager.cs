using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isPaused = false;
    public GameObject gameOverPanel;


    public Vector3 lastCheckpointPos;
    public Vector3 FirstCheckpointPos;
    public int health;
    public int currentLevel;

    private void Awake()
    {
        FirstCheckpointPos = new Vector3(0.0f, 2.2f, -15.0f);
        lastCheckpointPos = FirstCheckpointPos;
        health = 3;
        currentLevel = 1;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if((SceneManager.GetActiveScene().name != "MainMenu" || SceneManager.GetActiveScene().name != "Options") && !LevelLoader.loadingTransition) //No poder pausar en los menus
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start Button"))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        
    }

    public static void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Continue()
    {
        if (SaveSystem.CheckFileExist())
        {
            Data data = SaveSystem.LoadData();

            currentLevel = data.level;
            health = data.health;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            lastCheckpointPos = position;
        }
    }
    public void GameOver()
    {
        Debug.Log("Mamaste");
        gameOverPanel.SetActive(true);
    }
}
