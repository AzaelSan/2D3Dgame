using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Button retryBtn;
    public Button mainmenuBtn;

    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            GameManager.instance.gameOverPanel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        GameManager.isPaused = true;
        retryBtn.Select();
    }

    private void OnDisable()
    {
        GameManager.isPaused = false;
    }
}