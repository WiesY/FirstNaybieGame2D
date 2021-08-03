using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;

    public CharacterController2D playerObject;

    public float moveSpeed = 40f;

    private Animator animator;
    private float move = 0f;
    //private static float GroundedRadius = 0.4f;

    private bool jump = false;
    private bool crouch = false;

    //static Transform GroundCheck;

    //static LayerMask WhatIsGround;

    private Rigidbody2D rb;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move = joystick.Horizontal * moveSpeed; // - движения с помощью джостика

        move = Input.GetAxis("Horizontal") * moveSpeed; // - движения с помощью клавиатуры
        
        if (move != 0 && jump == false)
        {
            animator.SetBool("Move", true);
        }

        if (move == 0)
        {
            animator.SetBool("Move", false);
        }

        //if (joystick.Vertical > 0.5)  //- движения с помощью джостика
        if (Input.GetButtonDown("Jump")) // - движения с помощью клавиатуры
        {
            jump = true;
        }


        //if (joystick.Vertical < -0.5)  //- движения с помощью джостика
        if (Input.GetButtonDown("Crouch")) // - движения с помощью клавиатуры
        {
            crouch = true;
            animator.SetBool("Move", false);
            animator.SetBool("Crouch", true);
        }

        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("Crouch", false);
        }

        if (rb.velocity.y >= 0.01)
        {
            animator.SetBool("Move", false);
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

    public void Jump()
    {
        Debug.Log(1);
        jump = true;
    }
    //Collider2D collider = Physics2D.OverlapCircle(GroundCheck.position, GroundedRadius, WhatIsGround);
}