using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject options;
    public Button resumeBtn;
    public Button optionsBtn;
    public Button menuBtn;

    private void OnEnable()
    {
        GameManager.isPaused = true;
        resumeBtn.Select();
    }

    private void OnDisable()
    {
        if(!options.activeSelf)
        {
            GameManager.isPaused = false;
        }
    }
}
