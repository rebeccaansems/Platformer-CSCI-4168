using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public CanvasGroup winCanvas;

    private void Start()
    {
        winCanvas.alpha = 0;
        winCanvas.interactable = false;
        winCanvas.blocksRaycasts = false;
    }

    public void OnWin()
    {
        this.GetComponent<Timer>().StopTimer();
        winCanvas.interactable = true;
        winCanvas.blocksRaycasts = true;

        winCanvas.GetComponent<Animator>().SetBool("animateIn", true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
