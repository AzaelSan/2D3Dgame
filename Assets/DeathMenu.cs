using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathUI;
    public Button retryBtn;
    public Button mainmenuBtn;

    private void Awake()
    {
        //loader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
        deathUI.SetActive(false);
    }

    public void Update()
    {
        if (GameManager.instance.gameOver)
        {
            deathUI.SetActive(true);
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