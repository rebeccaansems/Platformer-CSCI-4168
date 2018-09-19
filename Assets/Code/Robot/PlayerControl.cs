using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    private new Rigidbody rigidbody;
    private Vector3 movement;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody.velocity = transform.forward * Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, Input.GetAxis("Horizontal") * moveSpeed, 0, Space.Self);
    }
}
