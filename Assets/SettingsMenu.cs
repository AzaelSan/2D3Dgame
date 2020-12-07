using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static bool mainMenu;
    public GameObject prevMenu;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Text volumeValue;
    public Slider volume;
    public Toggle fullScreen;

    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volume", 100);
        volumeValue.text = Mathf.Round(PlayerPrefs.GetFloat("volume", 20) + 80).ToString();
        fullScreen.isOn = Screen.fullScreen;

        resolutionDropdown.Select();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0;  i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Button B"))
        {
            Back();
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        volumeValue.text = Mathf.Round(volume + 80).ToString();
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        //PlayerPrefs.SetInt("fullS", isFullScreen ? 1 : 0);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Back()
    {
        if (mainMenu)
        {
            GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().LoadMainMenu();
        }
        else
        {
            if (prevMenu != null)
            {
                prevMenu.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
