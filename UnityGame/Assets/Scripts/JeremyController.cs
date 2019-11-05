using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeremyController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTouchingGround;
    private float speed;
    private float walkSpeed = 0.05f;
    private float runSpeed = 0.1f;
    private float turnSpeed = 1.5f;
    private float jumpHeight=5f;
    Rigidbody rbody;
    Animator animator;
    CapsuleCollider capsuleCollider;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        isTouchingGround = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * turnSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
        if (Input.GetKey(KeyCode.Space) && isTouchingGround)
        {
            Debug.Log("Jumpy jump!");
            rbody.AddForce(transform.up*jumpHeight,ForceMode.Impulse);
            isTouchingGround = false;
            animator.SetBool("isTouchingGround", false);
            Debug.Log(isTouchingGround);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            //TODO: W & S can be merged?
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("W");
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
                Debug.Log("W");
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

    }
    void OnCollisionEnter()
    {
        Debug.Log("Collision!");
        isTouchingGround = true;
        animator.SetBool("isTouchingGround",true);
    }

}
