using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;

    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerForceJump = 25f;

    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    // private Joystick joystick;

    private float movement;
    private bool facingRight = true;
    private bool isGrounded = false;
    private bool canOneJump = false;

    protected internal bool leftMove = false;
    protected internal bool rightMove = false;

    private void Awake()
    {
        playerController = this;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    //private void Start()
    //{
    //    joystick = transform.parent.GetComponent<SetCharacterScript>().joystick;
    //}

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        Jump();
    //    }
    //}

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal") * playerSpeed; // Keyboard move(desktop)
        //if (joystick.Horizontal > 0.1f) // Joystick move(telephone)
        //{
        //    movement = playerSpeed;
        //}
        //else if (joystick.Horizontal < -0.1f)
        //{
        //    movement = -playerSpeed;
        //}
        //else
        //{
        //    movement = 0;
        //}

        if (leftMove) // Buttons move(telephone)
        {
            movement = -playerSpeed;
        }
        else if (rightMove)
        {
            movement = playerSpeed;
        }
        else
        {
            movement = 0;
        }

        playerRigidbody.velocity = new Vector2(movement, playerRigidbody.velocity.y);

        if (!facingRight && movement > 0)
        {
            Flip();
        }
        else if (facingRight && movement < 0)
        {
            Flip();
        }

        if (movement != 0 && playerRigidbody.velocity.y < 0.1f)
        {
            playerAnimator.SetBool("Move", true);
        }
        else if (playerRigidbody.velocity.y >= 0.1f)
        {
            playerAnimator.SetBool("Move", false);
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Move", false);
            playerAnimator.SetBool("Jump", false);
        }
    }

    public void Jump()
    {
        if (isGrounded || canOneJump)
        {
            canOneJump = false;
            playerRigidbody.velocity = Vector2.up * playerForceJump;
            playerAnimator.SetBool("Move", false);
            playerAnimator.SetBool("Jump", true);
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
            StopCoroutine(OutGround());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            isGrounded = false;
            canOneJump = true;
            StartCoroutine(OutGround());
        }
    }

    private IEnumerator OutGround()
    {
        yield return new WaitForSeconds(0.071f);
        canOneJump = false;
    }
}