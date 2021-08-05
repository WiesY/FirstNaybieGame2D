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
    private bool outOfInvis = true;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetPlayer != null && outOfInvis)
        {
            TargetToPlayer();
        }
    }

    private void TargetToPlayer()
    {
        if (transform.position.x > targetPlayer.transform.position.x + 2)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed * 2, 0);
        }
        else if (transform.position.x < targetPlayer.transform.position.x + 2)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed * 2, 0);
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
    }

    private IEnumerator OutOfInvisible()
    {
        yield return new WaitForSeconds(1);
        outOfInvis = true;
    }
}