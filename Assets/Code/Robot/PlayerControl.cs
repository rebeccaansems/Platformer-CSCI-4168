using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed, rotateSpeed, jumpPower;
    public Transform baseOrb;

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
        animator.SetBool("isGrounded", IsGrounded());

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        currentMoveSpeed = moveSpeed;

        Debug.Log(GetRaycastHit().normal + " " + GetRaycastHit().distance);
        if (IsSlope())
        {
            currentMoveSpeed = moveSpeed * (1 - Mathf.Max(Mathf.Max(GetRaycastHit().normal.x, Mathf.Abs(GetRaycastHit().normal.x - 0.3f))));
            Debug.Log(currentMoveSpeed);
        }

        rigidbody.MovePosition(transform.position + transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * currentMoveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
    }

    private void Jump()
    {
        rigidbody.AddForce(0, jumpPower, 0, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return GetRaycastHit().distance < 0.71;
    }

    private bool IsSlope()
    {
        return GetRaycastHit().distance < 2 && (GetRaycastHit().normal.x >= 0.6f || GetRaycastHit().normal.x <= -0.3f);
    }

    private RaycastHit GetRaycastHit()
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(baseOrb.position, -Vector3.up, out hit);
        return hit;
    }
}
