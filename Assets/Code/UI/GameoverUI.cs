using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public CanvasGroup gameoverCanvas;

    private void Start()
    {
        gameoverCanvas.alpha = 0;
        gameoverCanvas.interactable = false;
        gameoverCanvas.blocksRaycasts = false;
    }

    public void OnGameover()
    {
        this.GetComponent<Timer>().StopTimer();
        gameoverCanvas.interactable = true;
        gameoverCanvas.blocksRaycasts = true;

        gameoverCanvas.GetComponent<Animator>().SetBool("animateIn", true);
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
