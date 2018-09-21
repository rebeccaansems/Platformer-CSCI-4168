using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObject : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
        {
            player.GetComponent<PlayerWaterHose>().SetFinalPoint(this.transform.GetComponent<Renderer>().bounds.center);
        }
    }
}
