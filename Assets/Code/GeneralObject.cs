using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObject : MonoBehaviour {

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseDown()
    {
        player.GetComponent<PlayerWaterHose>().SetFinalPoint(this.transform.position);
    }
}
