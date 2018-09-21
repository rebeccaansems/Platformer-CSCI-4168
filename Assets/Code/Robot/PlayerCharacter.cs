using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MalbersAnimations;

public class PlayerCharacter : MonoBehaviour
{

    public List<AnimalAIControl> animalsCurrentlyFollowing;

    private int numberOfPowerpacks;
    private float currentPowerpackLevel;

    public void Start()
    {
        numberOfPowerpacks = 0;
        currentPowerpackLevel = 0;
    }

    public void PowerpackGained()
    {
        numberOfPowerpacks++;
        if (numberOfPowerpacks == 1)
        {
            PowerpackEmptied();
        }
    }

    public int GetNumberPowerpacks()
    {
        return numberOfPowerpacks;
    }

    public void UsePowerpack()
    {
        if (currentPowerpackLevel > 0)
        {
            currentPowerpackLevel -= 0.02f;
        }

        if (currentPowerpackLevel <= 0 && numberOfPowerpacks > 0)
        {
            numberOfPowerpacks--;
            PowerpackEmptied();
        }
    }

    public void PowerpackEmptied()
    {
        if (numberOfPowerpacks > 0)
        {
            currentPowerpackLevel = 1;
        }
    }

    public float GetPowerpackLevel()
    {
        return currentPowerpackLevel;
    }

}
