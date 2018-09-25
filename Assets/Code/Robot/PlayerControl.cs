using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed, rotateSpeed, jumpPower;
    public Transform baseOrb, topOrb;

    private new Rigidbody rigidbody;
    private Animator animator;
    private PlayerCharacter playerCharacter;
    private PlayerWaterHose waterHose;
    private float groundHeight;

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        animator = this.GetComponentInChildren<Animator>();
        waterHose = this.GetComponentInChildren<PlayerWaterHose>();
        playerCharacter = this.GetComponentInChildren<PlayerCharacter>();
    }

    private void FixedUpdate()
    {
        //allow movements only if player is alive
        if (playerCharacter.isDead == false)
        {
            //if player isn't using the waterhose, allow movement
            if (waterHose.isPlaying == false)
            {
                Move();
                Rotate();
                animator.SetBool("isGrounded", IsGrounded());
            }

            //if player is on the ground and space is pressed, jump
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            //kill player if fully underwater (i.e. y is less than -2.5)
            if (this.transform.position.y < -2.5f)
            {
                this.GetComponent<PlayerCharacter>().KillPlayer();
            }
        }
    }

    private void Move()
    {
        //move straight if location to be moved to isn't excessively sloped
        if (IsSlope(transform.forward * Input.GetAxis("Vertical")) == false)
        {
            rigidbody.MovePosition(transform.position + transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        }
    }

    private void Rotate()
    {
        //rotate player
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
    }

    private void Jump()
    {
        //create force that allows jump
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        //see if player is currently on the ground, i.e. if less than 0.71 units from the ground
        return GetRaycastHit(-Vector3.up).distance < 0.71;
    }

    private bool IsSlope(Vector3 direction)
    {
        //see if direction to move in is a slope of greater than .8 or not
        return GetRaycastHit(direction).distance < 1 &&
            (Mathf.Abs(GetRaycastHit(direction).normal.x) > 0.8f || Mathf.Abs(GetRaycastHit(direction).normal.z) > 0.8f);
    }

    private RaycastHit GetRaycastHit(Vector3 direction)
    {
        //get first thing hit in given direction
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(baseOrb.position, direction, out hit);
        return hit;
    }
}
