using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MalbersAnimations;

public class PlayerCharacter : MonoBehaviour
{
    public CanvasGroup deathScreen;
    public List<AnimalAIControl> animalsCurrentlyFollowing;
    public bool isDead;

    private int numberOfPowerpacks;
    private float currentPowerpackLevel;
    private Vector3 startLocation;
    private Quaternion startRotation;

    public void Start()
    {
        //set everything to default values
        isDead = false;
        numberOfPowerpacks = 0;
        currentPowerpackLevel = 0;
        startLocation = this.transform.position;
        startRotation = this.transform.rotation;
    }

    public void PowerpackGained()
    {
        //if another powerpack is gained, increase total by 1
        numberOfPowerpacks++;

        //if this is the only powerpack, fill level to 1
        if (numberOfPowerpacks == 1)
        {
            currentPowerpackLevel = 1;
        }
    }

    public int GetNumberPowerpacks()
    {
        return numberOfPowerpacks;
    }

    //use some energy from current powerpack
    public void UsePowerpack()
    {
        //use some power from current powerpack
        if (currentPowerpackLevel > 0)
        {
            currentPowerpackLevel -= 0.02f;
        }

        //if powerpack is empty but we have full ones, replace empty powerpack with full one
        if (currentPowerpackLevel <= 0 && numberOfPowerpacks > 0)
        {
            numberOfPowerpacks--;
            currentPowerpackLevel = 1;
        }
    }

    public float GetPowerpackLevel()
    {
        return currentPowerpackLevel;
    }

    //start restarting process
    public void KillPlayer()
    {
        if (isDead == false)
        {
            isDead = true;
            StartCoroutine(RestartPlayer());
        }
    }

    public void GameOver()
    {
        Debug.Log("gameover");
    }

    //fade black screen in, reset location, fade black screen out, allow movement
    private IEnumerator RestartPlayer()
    {
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(FadeOut());
        ResetPlayerLocation();
        yield return new WaitForSeconds(0.6f);
        isDead = false;
    }

    //fade death screen in to total black (end: alpha = 1)
    private IEnumerator FadeIn()
    {
        while (deathScreen.alpha != 1)
        {
            deathScreen.alpha += 0.03f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    //fade death screen out from total black (end: alpha = 0)
    private IEnumerator FadeOut()
    {
        while (deathScreen.alpha != 0)
        {
            deathScreen.alpha -= 0.03f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    //set player location and rotation to defaults
    private void ResetPlayerLocation()
    {
        this.transform.position = startLocation;
        this.transform.rotation = startRotation;
    }
}
