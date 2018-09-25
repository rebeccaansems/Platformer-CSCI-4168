using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour {

    public void Setup()
    {
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
