using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public CanvasGroup pauseCanvas;
    public Dropdown resolutionDropdown, qualityDropdown;
    public Toggle fullscreenToggle;
    public PlayerCharacter player;

    private int currentResolutionIndex, currentQualityIndex;

    private void Start()
    {
        //set fullscreen toggle to off or on, dependent
        fullscreenToggle.isOn = Screen.fullScreen;

        //add all possible resolutions to resolutions dropdown
        resolutionDropdown.ClearOptions();
        List<string> allResolutions = Screen.resolutions.Select(x => x.width + ":" + x.height).ToList();
        resolutionDropdown.AddOptions(allResolutions);

        //get current resolution and show on dropdown
        currentResolutionIndex = allResolutions.IndexOf(Screen.width + ":" + Screen.height);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //get current quality level and show on dropdown
        currentQualityIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = currentQualityIndex;
        qualityDropdown.RefreshShownValue();
    }

    private void Update()
    {
        if (player.isDead == false && Input.GetButton("Pause"))
        {
            Time.timeScale = 0;
            pauseCanvas.alpha = 1;
            pauseCanvas.interactable = true;
            pauseCanvas.blocksRaycasts = true;
        }
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        pauseCanvas.alpha = 0;
        pauseCanvas.interactable = false;
        pauseCanvas.blocksRaycasts = false;
    }

    public void SetMusicVolume(float music)
    {
        Debug.Log(music);
    }

    public void SetSFXVolume(float sfx)
    {
        Debug.Log(sfx);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetResolution(int index)
    {
        Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
