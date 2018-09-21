using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MalbersAnimations;

public class PlayerCharacter : MonoBehaviour
{

    public List<AnimalAIControl> animalsCurrentlyFollowing;

    private int numberOfPowerpacks;

    public void PowerpackGained()
    {
        numberOfPowerpacks++;
    }

    public int GetNumberPowerpacks()
    {
        return numberOfPowerpacks;
    }
}
