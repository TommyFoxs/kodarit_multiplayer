using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float runSpeed = 14f;
    
    public float jumpheight = 1f;
    public float gravity = -9.8f;

    [SerializeField] private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.1f;

    public LayerMask groundMask;

    CharacterController controller;
    private Vector3 move;

    public Vector3 velocity;

    public bool doubleJump = true;
    
    public Animator animator;


    PhotonView view;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            CheckIfGrounded();
            Move();
            Jump();
        }
    }


    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        animator.SetBool("Grounded",isGrounded);

        if(isGrounded)
        {
            velocity.y = -1;
            doubleJump = true;
        }
        else{
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
   //     velocity.y += gravity * Time.deltaTime;
   //     controller.Move(velocity * Time.deltaTime);

    }

    public void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        move = transform.right * xAxis + transform.forward * zAxis;

        float targetSpeed  = Input.GetButton("Fire1") ? runSpeed : moveSpeed;

        if(move == Vector3.zero)
        {
            targetSpeed = 0;
        }

        animator.SetFloat("Speed",targetSpeed);
        controller.Move(move * targetSpeed * Time.deltaTime);
    }


    public void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        else if(Input.GetButtonDown("Jump") && doubleJump == true)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
            doubleJump = false;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    


}
