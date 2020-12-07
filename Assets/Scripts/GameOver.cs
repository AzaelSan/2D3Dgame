using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int gameOverScene;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScene = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            gameEnd();
        }
    }

    public void gameEnd()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(gameOverScene);
    }
}
