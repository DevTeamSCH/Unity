using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeremyController : MonoBehaviour
{
    private WalkState _walkState;
    // Start is called before the first frame update
    public bool isTouchingGround;
    private float speed;
    private float walkSpeed = 0.05f;
    private float runSpeed = 0.1f;
    private float turnSpeed = 1.5f;
    private float jumpHeight=5f;
    
    public WalkState WalkState{
        get { return _walkState; }
        set {
            _walkState = value;
            animator.SetBool("isWalking", value == WalkState.Walking);
            animator.SetBool("isRunning", value == WalkState.Running);
            animator.SetBool("isIdle", value == WalkState.Idle);
        }
    }
    
    Rigidbody rbody;
    Animator animator;
    CapsuleCollider capsuleCollider;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        isTouchingGround = true;
        WalkState=WalkState.Idle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var input = Input.GetAxis("Vertical");
        var y = Input.GetAxis("Horizontal") * turnSpeed;
        transform.Rotate(0, y, 0);
        if (Input.GetKey(KeyCode.Space) && isTouchingGround)
        {
            Debug.Log("Jumpy jump!");
            rbody.AddForce(transform.up*jumpHeight,ForceMode.Impulse);
            isTouchingGround = false;
            animator.SetBool("isTouchingGround", false);
            Debug.Log(isTouchingGround);
        }
        else if (input != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                WalkState=WalkState.Running;
                transform.Translate(0, 0, input*runSpeed);
            }
            else
            {
                WalkState=WalkState.Walking;
                transform.Translate(0, 0, input*walkSpeed);
            }
        }
        else
        {
            WalkState=WalkState.Idle;
        }

    }
    void OnCollisionEnter()
    {
        Debug.Log("Collision!");
        isTouchingGround = true;
        animator.SetBool("isTouchingGround",true);
    }

}
