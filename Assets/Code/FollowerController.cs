using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class FollowerController : MonoBehaviour
{
    public float maxDistanceToFollow;
    public Transform objectToFollow, nestLocation;

    private bool isFollowing, canFollow;
    private AnimalAIControl controller;
    private PlayerCharacter player;

    void Start()
    {
        controller = this.GetComponent<AnimalAIControl>();
        player = objectToFollow.GetComponent<PlayerCharacter>();

        canFollow = true;
        isFollowing = false;
    }

    void Update()
    {
        if (isFollowing && nestLocation == null)
        {
            //start to follow player and add controller to list of animals following player
            controller.SetTarget(objectToFollow);

            if (player.animalsCurrentlyFollowing.Contains(controller) == false)
            {
                player.animalsCurrentlyFollowing.Add(controller);
            }
        }
        else if (nestLocation != null)
        {
            controller.StopAnimal();
            controller.SetTarget(nestLocation);
            controller.StoppingDistance = 0.2f;
            canFollow = false;
        }
        else
        {
            if (controller.Agent.isActiveAndEnabled && controller.Agent.isStopped == false)
            {
                //stop following player and remove from list of animals following player
                controller.StopAnimal();
                controller.SetDestination(transform.position);
                player.animalsCurrentlyFollowing.Remove(controller);
            }
        }
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, objectToFollow.transform.position) < maxDistanceToFollow && canFollow)
        {
            isFollowing = !isFollowing;
        }
        else if (canFollow)
        {
            Debug.Log("Get closer");
        }
        else if (canFollow == false)
        {
            Debug.Log("Going to nest");
        }
    }
}
