using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTouchingGround;
    private float speed;
    private float walkSpeed = 0.05f;
    private float runSpeed = 0.1f;
    private float turnSpeed;
    private float jumpHeight;
    Rigidbody rigidbody;
    Animator animator;
    CapsuleCollider collider;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
        isTouchingGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isTouchingGround)
        {
            rigidbody.AddForce(0, jumpHeight, 0);
            isTouchingGround = false;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            //TODO: W & S can be merged?
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
            }
        }
        else
        {
            speed = walkSpeed;
            //TODO: W & S can be merged?
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
            }
        }
        void OnCollisonEnter()
        {
            isTouchingGround = true;
        }
        
        
    }
}
