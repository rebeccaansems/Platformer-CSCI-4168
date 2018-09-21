using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<string> collisionTags;

    private void OnCollisionEnter(Collision collide)
    {
        if (collisionTags.Contains(collide.gameObject.tag))
        {
            this.GetComponent<PlayerCharacter>().PowerpackGained();
            Destroy(collide.gameObject);
        }
    }
}
