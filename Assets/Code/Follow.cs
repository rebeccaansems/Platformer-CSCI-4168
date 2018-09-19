using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject objectToFollow;
    public float followSpeed, maxDistanceToFollow;

    private bool isFollowing;

    void Start()
    {

    }

    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, followSpeed);
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
