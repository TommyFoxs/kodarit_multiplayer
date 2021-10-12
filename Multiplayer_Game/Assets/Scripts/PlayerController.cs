using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float runSpeed = 14f;
    
    public float jumpheight = 14f;
    public float gravity = -9.8f;

    [SerializeField] private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.1f;

    public LayerMask groundMask;

    CharacterController controller;
    private Vector3 move;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
         
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Move();
    }


    private void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGrounded)
        {
            velocity.y = -1;
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


        controller.Move(move * targetSpeed * Time.deltaTime);
    }
}
