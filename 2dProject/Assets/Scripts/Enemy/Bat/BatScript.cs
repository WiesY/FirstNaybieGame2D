using System.Collections;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    private GameObject targetPlayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 2.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetPlayer != null)
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

        if (transform.localPosition.x > -0.5 && transform.localPosition.x < 0.5 && transform.localPosition.y == 0)
        {
            StartCoroutine(ChangeSimulated(false));
            animator.SetBool("IsFlying", false);
            enemyRigidbody.velocity = new Vector2(0, 0);
        }
    }

    private void TargetToPlayer()
    {
        if (transform.position.x > targetPlayer.transform.position.x + 1)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed * 2, 0);
        }
        else if (transform.position.x < targetPlayer.transform.position.x - 1)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed * 2, 0);
        }

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x);
        if (rayHit.transform.tag == "Trap")
        {
            enemyRigidbody.velocity = new Vector2(enemyRigidbody.velocity.x, enemySpeed);
        }
        else if (transform.position.y > targetPlayer.transform.position.y + 0.5)
        {
            enemyRigidbody.velocity = new Vector2(enemyRigidbody.velocity.x, -enemySpeed);
        }
        else if (transform.position.y < targetPlayer.transform.position.y - 0.5)
        {
            enemyRigidbody.velocity = new Vector2(enemyRigidbody.velocity.x, enemySpeed);
        }        
    }

    public void SetTriggerPlayer(GameObject trigger)
    {
        targetPlayer = trigger;
        if (trigger != null)
        {
            StartCoroutine(ChangeSimulated(true));
            animator.SetBool("IsFlying", true);
        }
    }

    private IEnumerator ChangeSimulated(bool simulated)
    {
        yield return new WaitForSeconds(1);
        enemyRigidbody.simulated = simulated;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
    }
}