using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed, rotateSpeed, jumpPower;
    public Transform baseOrb;

    private new Rigidbody rigidbody;
    private float groundHeight;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        rigidbody.MovePosition(transform.position + transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
    }

    private void Jump()
    {
        rigidbody.AddForce(0, jumpPower, 0, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(baseOrb.position, -Vector3.up, out hit);
        return hit.distance < 0.61;
    }
}
