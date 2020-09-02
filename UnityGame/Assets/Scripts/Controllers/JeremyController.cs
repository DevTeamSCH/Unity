using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeremyController : MonoBehaviour
{
    private bool _isTouchingGround;
    private float speed=6;
    float rotationSmoothing = 0.1f;
    float rotationSmoothVelocity;
    public Transform cam;

    private float walkSpeed = 0.05f;
    private float runSpeed = 0.1f;
    private float turnSpeed = 1.5f;
    private float jumpHeight=5f;

    public CharacterController characterController;
    
    Rigidbody rbody;
    Animator animator;
    CapsuleCollider capsuleCollider;
    
    public bool IsTouchingGround{
        get{ return _isTouchingGround; }
        set{
            _isTouchingGround = value;
            animator.SetBool("isTouchingGround", value);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
       // animator.SetBool("isWalking", false);
     //animator.SetBool("isRunning", false);
        //animator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude>=0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSmoothVelocity, rotationSmoothing);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        /*transform.Translate(0, 0, horizontal);
        transform.Rotate(0, vertical, 0);
        if (Input.GetKey(KeyCode.Space) && IsTouchingGround)
        {
            Debug.Log("Jumpy jump!");
            rbody.AddForce(transform.up*jumpHeight,ForceMode.Impulse);
            IsTouchingGround = false;
            Debug.Log(IsTouchingGround);
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
        }*/

    }
    void OnCollisionEnter(Collision coll)
    {
       /* Debug.Log("Collision!");
        if(coll.gameObject.CompareTag("Ground"))
            IsTouchingGround = true;
        // else: check for Booster, Enemy, etc.*/
    }

}
