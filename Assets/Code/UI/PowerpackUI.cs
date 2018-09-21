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
        if (prevNumPowerpacks != player.GetNumberPowerpacks())
        {
            powerpackNumberText.text = "<size=50>x</size>" + Mathf.Max((player.GetNumberPowerpacks() - 1), 0).ToString("00");
            prevNumPowerpacks = player.GetNumberPowerpacks();
        }

        if (prevPowerLevel != player.GetPowerpackLevel())
        {
            powerSlider.value = player.GetPowerpackLevel();
            prevPowerLevel = player.GetPowerpackLevel();
        }
    }
}
