using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private GameManager gm;

    public float transitionTime = 1.0f;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    public void Continue()
    {
        gm.Continue();
        StartCoroutine(LoadLevel(gm.currentLevel));
    }

    public void LoadNewGame()
    {
        gm.lastCheckpointPos = new Vector3(0.0f, 2.2f, -15.0f);
        gm.health = 3;
        gm.currentLevel = 1;
        StartCoroutine(LoadLevel(1));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        GameManager.isPaused = false;
        StartCoroutine(LoadLevel(0));
    }

    public void LoadDeathScreen()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void LoadOptions()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void Exit()
    {
        Application.Quit(); 
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
