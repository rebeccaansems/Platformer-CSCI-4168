using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public CanvasGroup winCanvas, nextLevelButton;
    public Text winText;

    private void Start()
    {
        winCanvas.alpha = 0;
        winCanvas.interactable = false;
        winCanvas.blocksRaycasts = false;
    }

    public void OnWin()
    {
        //this is the last level
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount)
        {
            winText.text = "you win!";
            nextLevelButton.alpha = 0;
            nextLevelButton.interactable = false;
        }
        else
        {
            winText.text = "level cleared";
            nextLevelButton.alpha = 1;
            nextLevelButton.interactable = true;
        }

        //stop time and make win canvas appear
        this.GetComponent<Timer>().StopTimer();
        winCanvas.blocksRaycasts = true;

        winCanvas.GetComponent<Animator>().SetBool("animateIn", true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
