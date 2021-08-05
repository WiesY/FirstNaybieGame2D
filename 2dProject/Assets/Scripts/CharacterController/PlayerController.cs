using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D playerObject;
    public float moveSpeed = 0.5f;

    private Joystick joystick;
    private Animator animator;

    private float move = 0f;
    private bool jump = false;
    private bool crouch = false;

    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        joystick = transform.parent.GetComponent<SetCharacterScript>().joystick;
    }

    void Update()
    {
        //if (joystick.Horizontal > 0.1f)
        //{
        //    move = moveSpeed;
        //}
        //else if(joystick.Horizontal < -0.1f)
        //{
        //    move = -moveSpeed;
        //}
        //else
        //{
        //    move = 0;
        //}
        // move = joystick.Horizontal * moveSpeed; // - движения с помощью джостика

        move = Input.GetAxis("Horizontal") * moveSpeed; // - движения с помощью клавиатуры
        
        if (move != 0 && jump == false)
        {
            animator.SetBool("Move", true);
        }

        if (move == 0)
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetButtonDown("Jump")) // - движения с помощью клавиатуры
        {
            jump = true;
        }

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
        jump = true;
    }
}