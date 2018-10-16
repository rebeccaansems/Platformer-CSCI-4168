using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{

    public float speed;
    public Vector3 pointA, pointB;

    private Vector3 goingToPoint;

    private void Start()
    {
        goingToPoint = pointA;
    }

    //bounce between two points
    void FixedUpdate()
    {
        if (Vector3.Distance(goingToPoint, this.transform.position) < 0.1f)
        {
            if (goingToPoint == pointA)
            {
                goingToPoint = pointB;
            }
            else
            {
                goingToPoint = pointA;
            }
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, goingToPoint, speed * Time.deltaTime);
    }
}
