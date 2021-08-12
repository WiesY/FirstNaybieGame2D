using System.Collections;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    private GameObject targetPlayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 2.5f;
    private bool moveUp = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetPlayer != null && enemyRigidbody.simulated)
        {
            TargetToPlayer();
        }
        else if (targetPlayer == null && transform.localPosition != new Vector3(0, 0, 0))
        {
            GoToHome();
        }
    }

    private void GoToHome()
    {
        if (transform.localPosition.x > 0.5)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed, enemyRigidbody.velocity.y);
        }
        else if (transform.localPosition.x < -0.5)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed, enemyRigidbody.velocity.y);
        }

        if (transform.localPosition.y < 0)
        {
            enemyRigidbody.velocity = new Vector2(enemyRigidbody.velocity.x, enemySpeed);
        }

        if (transform.localPosition.y > -0.01 && transform.localPosition.y < 0.01)
        {
            enemyRigidbody.simulated = false;
            // StartCoroutine(ChangeSimulated(false));
            animator.SetBool("IsFlying", false);
            enemyRigidbody.velocity = new Vector2(0, 0);
        }
    }

    private void TargetToPlayer()
    {
        //RaycastHit2D rayHit;
        //if (!spriteRenderer.flipX)
        //{
        //    rayHit = Physics2D.Raycast(transform.GetChild(0).transform.position, Vector2.right, 150f);
        //}
        //else
        //{
        //    rayHit = Physics2D.Raycast(transform.GetChild(1).transform.position, Vector2.left, 150f);
        //}

        //Debug.Log(rayHit.collider.tag);
        if (moveUp)
        {
            enemyRigidbody.velocity = new Vector2(0, enemySpeed * 2);
            return;
        }
        else if (transform.position.y > targetPlayer.transform.position.y + 0.5)
        {
            enemyRigidbody.velocity = new Vector2(enemyRigidbody.velocity.x, -enemySpeed);
        }
        else if (transform.position.y < targetPlayer.transform.position.y - 0.5)
        {
            enemyRigidbody.velocity = new Vector2(enemyRigidbody.velocity.x, enemySpeed);
        }

        if (transform.position.x > targetPlayer.transform.position.x + 0.5)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed * 2, enemyRigidbody.velocity.y);
        }
        else if (transform.position.x < targetPlayer.transform.position.x - 0.5)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed * 2, enemyRigidbody.velocity.y);
        }
    }

    public void SetTriggerPlayer(GameObject trigger)
    {
        targetPlayer = trigger;
        if (trigger != null)
        {
            animator.SetBool("IsFlying", true);
            StartCoroutine(ChangeSimulated(true));
        }
    }

    private IEnumerator ChangeSimulated(bool simulated)
    {
        while (true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("BatFlyingAnimation"))
            {
                Debug.Log(5);
                enemyRigidbody.simulated = simulated;
                yield break;
            }
            yield return new WaitForSeconds(0.75f);
        }               
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            moveUp = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            moveUp = false;
        }
    }
}