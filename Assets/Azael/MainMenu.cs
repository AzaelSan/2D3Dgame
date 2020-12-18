using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject continue_Btn;

    void Start()
    {
        SettingsMenu.mainMenu = true;
        PlayerCombat.gameover = false;
        continue_Btn.SetActive(SaveSystem.CheckFileExist());
    }
}
