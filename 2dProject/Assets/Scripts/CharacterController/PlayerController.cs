using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public CharacterController2D playerObject;

    //public float moveSpeed = 0.5f;
    //private Rigidbody2D rb;
    //private Joystick joystick;
    //private Animator animator;

    //private float move = 0f;
    //private bool jump = false;
    //private bool crouch = false;

    //void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    rb = GetComponent<Rigidbody2D>();
    //    joystick = transform.parent.GetComponent<SetCharacterScript>().joystick;
    //}

    //void Update()
    //{
    //    if (joystick.Horizontal > 0.1f)
    //    {
    //        move = moveSpeed;
    //        animator.SetBool("Move", true);
    //    }
    //    else if(joystick.Horizontal < -0.1f)
    //    {
    //        move = -moveSpeed;
    //        animator.SetBool("Move", true);
    //    }
    //    else
    //    {
    //        move = 0;
    //        animator.SetBool("Move", false);
    //    }
    //    // move = joystick.Horizontal * moveSpeed; // - движения с помощью джостика

    //    // move = Input.GetAxis("Horizontal") * moveSpeed; // - движения с помощью клавиатуры

    //    if (Input.GetButton("Jump") && rb.velocity.y <= 0.1f) // - движения с помощью клавиатуры
    //    {

    //        jump = true;
    //        animator.SetTrigger("Jump");
    //    }

    //    if (Input.GetButton("Crouch")) // - движения с помощью клавиатуры
    //    {
    //        animator.SetBool("Move", false);
    //        crouch = true;
    //        animator.SetBool("Crouch", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("Crouch", false);
    //        crouch = false;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    playerObject.Move(move, crouch, false);

    //    jump = false;
    //}

    //public void Jump()
    //{
    //    if (rb.velocity.y <= 0.1f)
    //    {
    //        rb.velocity = new Vector2(0, 25f);
    //        jump = true;
    //        animator.SetTrigger("Jump");
    //    }
    //}

    [SerializeField] private Transform checkGroundObject;
    [SerializeField] private float checkRadius;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerForceJump = 25f;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private Joystick joystick;

    private float movement;
    private bool facingRight = true;
    private bool isGrounded = false;
    private int speedInWater = 1;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        joystick = transform.parent.GetComponent<SetCharacterScript>().joystick;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // movement = Input.GetAxis("Horizontal");
        movement = joystick.Horizontal; // joystick
        playerRigidbody.velocity = new Vector2(movement * playerSpeed / speedInWater, playerRigidbody.velocity.y);

        if (!facingRight && movement > 0)
        {
            Flip();
        }
        else if (facingRight && movement < 0)
        {
            Flip();
        }

        if (movement != 0)
        {
            playerAnimator.SetBool("Move", true);
        }
        else
        {
            playerAnimator.SetBool("Move", false);
        }
    }

    public void Jump()
    {
        //if (Physics2D.OverlapCircle(checkGroundObject.position, checkRadius, whatIsGround))
        if (isGrounded)
        {
            playerRigidbody.velocity = Vector2.up * playerForceJump / speedInWater;
            playerAnimator.SetTrigger("Jump");
        }
    }

    private void Flip()
    {
        var tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            speedInWater = 2;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            speedInWater = 1;
            isGrounded = false;
        }
    }
}