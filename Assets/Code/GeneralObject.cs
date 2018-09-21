using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObject : MonoBehaviour
{
    private GameObject player;
    private FireController fire;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fire = this.GetComponentInChildren<FireController>();
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 30)
        {
            player.GetComponent<PlayerWaterHose>().SetFinalPoint(this.transform.GetComponent<Renderer>().bounds.center);
            player.GetComponent<PlayerWaterHose>().StartPuttingoutFire(fire);
        }
    }
}
