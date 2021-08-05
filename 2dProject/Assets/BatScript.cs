using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    private GameObject targetPlayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 2.5f;
    private bool moveToLeftPoint = true;

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
        if (transform.localPosition.x > 1)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed, 0);
            moveToLeftPoint = true;
        }
        else if (transform.localPosition.x < -1)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed, 0);
            moveToLeftPoint = false;
        }

        if (transform.localPosition.x > -1 && transform.localPosition.x < 1 && transform.localPosition.y < 0)
        {
            var tempVelocity = enemyRigidbody.velocity;
            tempVelocity.y = enemySpeed / 2;
            enemyRigidbody.velocity = tempVelocity;
        }

        if (transform.localPosition.x > -1 && transform.localPosition.x < 1 && transform.localPosition.y > -1 && transform.localPosition.y < 1)
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
            moveToLeftPoint = true;
        }
        else if (transform.position.x < targetPlayer.transform.position.x - 1)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed * 2, 0);
            moveToLeftPoint = false;
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(0, 0);
        }

        if (transform.position.y > targetPlayer.transform.position.y)
        {
            var tempVelocity = enemyRigidbody.velocity;
            tempVelocity.y = -enemySpeed;
            enemyRigidbody.velocity = tempVelocity;
        }
        else if (transform.position.x < targetPlayer.transform.position.x)
        {
            var tempVelocity = enemyRigidbody.velocity;
            tempVelocity.y = enemySpeed;
            enemyRigidbody.velocity = tempVelocity;
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