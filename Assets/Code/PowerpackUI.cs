using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerpackUI : MonoBehaviour
{

    public Text powerpackNumberText;
    public PlayerCharacter player;

    private int prevNumPowerpacks;

    void Start()
    {
        prevNumPowerpacks = -1;
    }

    void Update()
    {
        if (prevNumPowerpacks != player.GetNumberPowerpacks())
        {
            powerpackNumberText.text = "<size=40>x</size>" + player.GetNumberPowerpacks().ToString("00");
            prevNumPowerpacks = player.GetNumberPowerpacks();
        }
    }
}
