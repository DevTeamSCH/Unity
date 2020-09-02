using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeremyController : MonoBehaviour
{
    private float speed = 6;
    float rotationSmoothing = 0.1f;
    float rotationSmoothVelocity;
    public Transform cam;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundIndicator;
    public float groundDistance = 1.0f;
    public LayerMask groundMask;
    private bool isGrounded;


    //TODO change to state machine
    bool fps = true;

    private float walkSpeed = 0.05f;
    private float runSpeed = 0.1f;
    private float turnSpeed = 1.5f;
    private float jumpHeight = 1f;

    public CharacterController characterController;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundIndicator.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) velocity.y = -2;
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;

        Vector3 moveDirection;

        if (direction.magnitude >= 0.1)
        {

            if (fps)
            {
                moveDirection = transform.right * horizontal + transform.forward * vertical;
            }
            else
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSmoothVelocity, rotationSmoothing);
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
                moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            }
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

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
