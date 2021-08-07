using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        movement = Input.GetAxis("Horizontal") * playerSpeed; // Keyboard
        //if (joystick.Horizontal > 0.1f) // Joystick
        //{
        //    movement = playerSpeed;
        //}
        //else if(joystick.Horizontal < -0.1f)
        //{
        //    movement = -playerSpeed;
        //}
        //else
        //{
        //    movement = 0;
        //}
        
        playerRigidbody.velocity = new Vector2(movement / speedInWater, playerRigidbody.velocity.y);

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
        Debug.Log(1);
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
            Debug.Log("On Ground");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isGrounded = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.gameObject.layer);
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
    //    {
    //        speedInWater = 2;
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
    //    {
    //        speedInWater = 1;
    //        isGrounded = false;
    //    }
    //}
}