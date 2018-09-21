using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collide)
    {
        //if player collides with a powerpack, gain the pack and destroy it's game object
        if (collide.gameObject.tag == "Powerpack")
        {
            this.GetComponent<PlayerCharacter>().PowerpackGained();
            Destroy(collide.gameObject);
        }
    }
}
