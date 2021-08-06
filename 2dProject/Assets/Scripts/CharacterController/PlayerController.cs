using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D playerObject;
    public float moveSpeed = 0.5f;

    private Rigidbody2D rb;
    private Joystick joystick;
    private Animator animator;

    private float move = 0f;
    private bool jump = false;
    private bool crouch = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        joystick = transform.parent.GetComponent<SetCharacterScript>().joystick;
    }

    void Update()
    {
        if (joystick.Horizontal > 0.1f)
        {
            move = moveSpeed;
            animator.SetBool("Move", true);
        }
        else if(joystick.Horizontal < -0.1f)
        {
            move = -moveSpeed;
            animator.SetBool("Move", true);
        }
        else
        {
            move = 0;
            animator.SetBool("Move", false);
        }
        // move = joystick.Horizontal * moveSpeed; // - движения с помощью джостика

        // move = Input.GetAxis("Horizontal") * moveSpeed; // - движения с помощью клавиатуры

        if (Input.GetButton("Jump") && rb.velocity.y <= 0.1f) // - движения с помощью клавиатуры
        {
            
            jump = true;
            animator.SetTrigger("Jump");
        }

        if (Input.GetButton("Crouch")) // - движения с помощью клавиатуры
        {
            animator.SetBool("Move", false);
            crouch = true;
            animator.SetBool("Crouch", true);
        }
        else
        {
            animator.SetBool("Crouch", false);
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        playerObject.Move(move, crouch, false);

        jump = false;
    }

    public void Jump()
    {
        if (rb.velocity.y <= 0.1f)
        {
            rb.velocity = new Vector2(0, 25f);
            jump = true;
            animator.SetTrigger("Jump");
        }
    }
}