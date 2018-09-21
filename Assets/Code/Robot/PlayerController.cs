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
            Debug.Log("COLLECT");
            Destroy(collide.gameObject);
        }
    }
}
