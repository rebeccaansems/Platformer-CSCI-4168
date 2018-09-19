using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public SphereCollider objectToFollow;
    public float followSpeed, maxDistanceToFollow, minFollowDistance;

    private bool isFollowing;

    void Start()
    {

    }

    void Update()
    {
        if (isFollowing && Vector3.Distance(transform.position, objectToFollow.transform.position) > minFollowDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, objectToFollow.ClosestPoint(transform.position), followSpeed);
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
