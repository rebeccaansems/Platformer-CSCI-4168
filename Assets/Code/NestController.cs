using MalbersAnimations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestController : MonoBehaviour
{
    public PlayerCharacter characterController;
    public float maxDistanceToFollow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, characterController.transform.position) < maxDistanceToFollow)
        {
            foreach(AnimalAIControl animal in characterController.animalsCurrentlyFollowing)
            {
                animal.GetComponent<FollowerController>().nestLocation = (this.transform);
            }
        }
        else
        {
            Debug.Log("Get closer");
        }
    }
}
