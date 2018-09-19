using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    private new Rigidbody rigidbody;

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
        rigidbody.MovePosition(transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, 
            Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);
    }
}
