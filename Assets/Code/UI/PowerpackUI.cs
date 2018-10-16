using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerpackUI : MonoBehaviour
{
    public Text powerpackNumberText;
    public Slider powerSlider;
    public PlayerCharacter player;

    private int prevNumPowerpacks;
    private float prevPowerLevel;

    void Start()
    {
        prevNumPowerpacks = -1;
        prevPowerLevel = -1;
    }

    void Update()
    {
        //show current number of full powerpacks
        if (prevNumPowerpacks != player.GetNumberPowerpacks())
        {
            powerpackNumberText.text = player.GetNumberPowerpacks().ToString("00");
            prevNumPowerpacks = player.GetNumberPowerpacks();
        }

        //show current level of current powerpack
        if (prevPowerLevel != player.GetPowerpackLevel())
        {
            powerSlider.value = player.GetPowerpackLevel();
            prevPowerLevel = player.GetPowerpackLevel();
        }
    }
}
