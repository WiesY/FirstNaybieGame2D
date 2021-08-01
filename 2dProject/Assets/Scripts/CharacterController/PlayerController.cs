using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;

    public CharacterController2D playerObject;

    public Animator animator;

    private float move = 0f;
    public float moveSpeed = 40f;
    //private static float GroundedRadius = 0.4f;

    bool jump = false;
    bool crouch = false;

    //static Transform GroundCheck;

    //static LayerMask WhatIsGround;

    Rigidbody2D Rb;


    void Start()
    {
        animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move = joystick.Horizontal * moveSpeed; // - движения с помощью джостика

        //move = (Input.GetAxis("Horizontal")) * moveSpeed; // - движения с помощью клавиатуры
        
        if (move != 0 && jump == false)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Move", true);
        }

        if (move == 0 && jump == false)
        {
            animator.SetBool("Move", false);
            animator.SetBool("Idle", true);
        }

        if (joystick.Vertical > 0.5)
        //if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        //if (Input.GetButtonDown("Crouch"))
        if (joystick.Vertical < -0.5)
        {
            crouch = true;
            animator.SetBool("Move", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Crouch", true);
        }
        
        else
        //if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("Crouch", false);
        }

        if (Rb.velocity.y != 0)
        {
            animator.SetBool("Move", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Jump", true);
        }
        else
        {

            animator.SetBool("Jump", false);

        }
    }
    private void FixedUpdate()
    {
        playerObject.Move(move, crouch, jump);
       
        jump = false;

    }

    //Collider2D collider = Physics2D.OverlapCircle(GroundCheck.position, GroundedRadius, WhatIsGround);
}
