using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    //for Animation
    private Animator animator;
    bool isRunning= false;
    bool isJumping = false;

    public CharacterController controller; // its a motor that drive character , we have to tell where we have to go
    public Transform cam;
    public float speed= 6f;
    // Start is called before the first frame update
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Start()
    {
         animator = this.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // animation
        isRunning= Input.GetKey(KeyCode.W);
        animator.SetBool("run",isRunning);

        isJumping = Input.GetButtonDown("Jump");
        animator.SetBool("jump",isJumping);

        float horizonatal = Input.GetAxisRaw("Horizontal");  // -1 to 1  -> -1 = a  and +1 = d
        float vertical = Input.GetAxisRaw("Vertical");       //
        Vector3 direction = new Vector3(horizonatal,0f,vertical).normalized; // if we hold down two keys and go diagonally and don't go faster so we normalised it

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle= Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;   // as we are moving anticlockwise so we as pass tan(x/y) instead of tan(y/x)  and Rad2Deg is for converting
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity ,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle ,0f);

            Vector3 moveDir= Quaternion.Euler(0f, targetAngle , 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

    }

    // public CharacterController controller;
    // private Vector3 playerVelocity;
    // private bool groundedPlayer;
    // private float playerSpeed = 4.0f;
    // private float jumpHeight = 1.0f;
    // private float gravityValue = -9.81f;

    // private void Start()
    // {
    //     animator = this.GetComponentInChildren<Animator>();
    //     controller = this.GetComponent<CharacterController>();
    // }

    // void Update()
    // {
    //     //animation
    //     isRunning= Input.GetKey(KeyCode.W);
    //     animator.SetBool("run",isRunning);

    //     isJumping = Input.GetButtonDown("Jump");
    //     animator.SetBool("jump",isJumping);

    //     //player movement code
    //     groundedPlayer = controller.isGrounded;
    //     if (groundedPlayer && playerVelocity.y < 0)
    //     {
    //         playerVelocity.y = 0f;
    //     }

    //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //     controller.Move(move * Time.deltaTime * playerSpeed);



    //     if (move != Vector3.zero)
    //     {
    //         gameObject.transform.forward = move;
    //     }


    //     // Changes the height position of the player..
    //     if (Input.GetButtonDown("Jump") && groundedPlayer)
    //     {   
    //         playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

    //     }

    //     playerVelocity.y += gravityValue * Time.deltaTime;
    //     controller.Move(playerVelocity * Time.deltaTime);
    // }
}
