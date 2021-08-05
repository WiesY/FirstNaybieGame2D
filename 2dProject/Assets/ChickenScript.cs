using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private ParticleSystem chickenParticleSystem;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 5f;
    private bool moveToLeftPoint = true;
    private int enemyHp = 3;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PatrulZone();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var tempVelocity = collision.GetComponent<Rigidbody2D>().velocity;
            tempVelocity.y = 15f;
            collision.GetComponent<Rigidbody2D>().velocity = tempVelocity;
            HitEnemy();
        }
    }

    private void HitEnemy()
    {
        if (enemyHp - 1 >= 1)
        {
            enemyHp--;
        }
        else
        {
            var tempPosition = gameObject.transform.position;
            tempPosition.y -= 0.35f;
            chickenParticleSystem.transform.position = tempPosition;
            chickenParticleSystem.Play();
            Destroy(gameObject);
        }
    }
}