using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonScript : MonoBehaviour
{
    private GameObject targetPlayer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 2.5f; // Patrul speed
    private bool canMove = true;


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
    }

    private void TargetToPlayer()
    {
        if (transform.position.x > targetPlayer.transform.position.x + 1 && canMove)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed * 2, 0);
        }
        else if (transform.position.x < targetPlayer.transform.position.x + 1 && canMove)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed * 2, 0);
        }

        if (Vector2.Distance(transform.position, targetPlayer.transform.position) < 2f)
        {
            enemyRigidbody.velocity = new Vector2(0, 0);
            StartCoroutine(OutOfInvisible());
            canMove = false;
            animator.SetTrigger("CanHitPlayer");
        }
    }

    public void SetTriggerPlayer(GameObject trigger)
    {
        targetPlayer = trigger;
        if (trigger != null)
        {
            StartCoroutine(OutOfInvisible());
            animator.SetBool("TargetToPlayer", true);
        }
        else
        {
            enemyRigidbody.velocity = new Vector2(0, 0);
            animator.SetBool("TargetToPlayer", false);
            canMove = false;
        }
    }

    private IEnumerator OutOfInvisible()
    {
        yield return new WaitForSeconds(1);
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
    }
}