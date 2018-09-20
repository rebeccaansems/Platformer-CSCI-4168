using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed, rotateSpeed, jumpPower;
    public Transform baseOrb, topOrb;

    private new Rigidbody rigidbody;
    private Animator animator;
    private float groundHeight, currentMoveSpeed;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        animator = this.GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        animator.SetBool("isGrounded", IsGrounded());

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move()
    {
        currentMoveSpeed = moveSpeed;

        if (IsSlope(transform.forward * Input.GetAxis("Vertical")) == false)
        {
            rigidbody.MovePosition(transform.position + transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * currentMoveSpeed);
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return GetRaycastHit(-Vector3.up).distance < 0.71;
    }

    private bool IsSlope(Vector3 direction)
    {
        return GetRaycastHit(direction).distance < 1 &&
            (Mathf.Abs(GetRaycastHit(direction).normal.x) > 0.8f || Mathf.Abs(GetRaycastHit(direction).normal.z) > 0.8f);
    }

    private RaycastHit GetRaycastHit(Vector3 direction)
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(baseOrb.position, direction, out hit);
        return hit;
    }
}
