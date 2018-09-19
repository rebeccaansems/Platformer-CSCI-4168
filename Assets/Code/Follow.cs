using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MalbersAnimations;

public class Follow : MonoBehaviour
{
    public float maxDistanceToFollow;
    public Transform objectToFollow;

    private bool isFollowing;
    private AnimalAIControl controller;

    void Start()
    {
        controller = this.GetComponent<AnimalAIControl>();
    }

    void Update()
    {
        if (isFollowing)
        {
            controller.SetTarget(objectToFollow);
        }
        else
        {
            if (controller.Agent.isActiveAndEnabled && controller.Agent.isStopped == false)
            {
                controller.StopAnimal();
                controller.SetDestination(transform.position);
            }
        }
    }

    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, objectToFollow.transform.position) < maxDistanceToFollow)
        {
            isFollowing = !isFollowing;
        }
        else
        {
            Debug.Log("Get closer");
        }
    }
}
