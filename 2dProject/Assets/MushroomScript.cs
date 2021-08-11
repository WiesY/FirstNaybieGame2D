using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;

    private GameObject targetPlayer;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 1.75f; // Patrul speed
    private bool moveToLeftPoint = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (targetPlayer != null)
        {
            TargetToPlayer();
        }
        else
        {
            PatrulZone();
        }
    }

    private void PatrulZone()
    {
        if (transform.localPosition.x <= movePoints[0].transform.localPosition.x)
        {
            spriteRenderer.flipX = true;
            moveToLeftPoint = false;
        }
        else if (transform.localPosition.x >= movePoints[1].transform.localPosition.x)
        {
            spriteRenderer.flipX = false;
            moveToLeftPoint = true;
        }

        if (transform.localPosition.x >= movePoints[0].transform.localPosition.x && moveToLeftPoint)
        {
            enemyRigidbody.velocity = new Vector2(-enemySpeed, 0);
        }
        if (transform.localPosition.x <= movePoints[1].transform.localPosition.x && !moveToLeftPoint)
        {
            enemyRigidbody.velocity = new Vector2(enemySpeed, 0);
        }
    }

    private void TargetToPlayer()
    {
        if (transform.position.x > targetPlayer.transform.position.x)
        {
            spriteRenderer.flipX = false;
            enemyRigidbody.velocity = new Vector2(-enemySpeed * 1.25f, 0);
            moveToLeftPoint = true;
        }
        else if (transform.position.x < targetPlayer.transform.position.x)
        {
            spriteRenderer.flipX = true;
            enemyRigidbody.velocity = new Vector2(enemySpeed * 1.25f, 0);
            moveToLeftPoint = false;
        }
    }

    public void SetTriggerPlayer(GameObject trigger)
    {
        targetPlayer = trigger;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
    }
}