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
         CheckIfGrounded();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CheckIfGrounded(){
        
    }
}
