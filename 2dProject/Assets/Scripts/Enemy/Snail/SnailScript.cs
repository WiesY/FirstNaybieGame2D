using UnityEngine;

public class SnailScript : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float enemySpeed = 0.35f;
    private bool moveToLeftPoint = true;


    private void Awake()
    {
        animator = GetComponent<Animator>();
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
    }
}