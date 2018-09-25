using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public CanvasGroup gameoverCanvas;

    public void Setup()
    {
        gameoverCanvas.GetComponent<CanvasGroup>().interactable = true;
        gameoverCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
