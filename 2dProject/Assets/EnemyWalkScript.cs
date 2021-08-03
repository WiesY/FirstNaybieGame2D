using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkScript : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;

    public GameObject targetPlayer;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D enemyRigidbody;

    private float speed = 1.5f;
    private bool moveToLeftPoint = true;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    //private void Update()
    //{
    //    if (targetPlayer != null)
    //    {
    //        pigIsAngry = true;
    //    }
    //    else
    //    {
    //        pigIsAngry = false;
    //        PatrulZone();
    //    }
    //}

    private void FixedUpdate()
    {        
        if (targetPlayer != null)
        {
            //TargetToPlayer();
        }
        else
        {
            //PatrulZone();        
        }
    }

    //private void PatrulZone()
    //{
    //    if (transform.localPosition.x <= movePoints[0].transform.localPosition.x)
    //    {
    //        spriteRenderer.flipX = true;
    //        moveToLeftPoint = false;
    //    }
    //    else if (transform.localPosition.x >= movePoints[1].transform.localPosition.x)
    //    {
    //        spriteRenderer.flipX = false;
    //        moveToLeftPoint = true;
    //    }

    //    if (transform.localPosition.x >= movePoints[0].transform.localPosition.x && moveToLeftPoint)
    //    {            
    //        enemyRigidbody.velocity = new Vector2(-3.5f, 0);
    //    }
    //    if (transform.localPosition.x <= movePoints[1].transform.localPosition.x && !moveToLeftPoint)
    //    {            
    //        enemyRigidbody.velocity = new Vector2(3.5f, 0);
    //    }
    //}

    //private void TargetToPlayer()
    //{        
    //    if (transform.position.x > targetPlayer.transform.position.x)
    //    {
    //        spriteRenderer.flipX = false;
    //        enemyRigidbody.velocity = new Vector2(-3.5f, 0);
    //        moveToLeftPoint = true;
    //    }
    //    else if (transform.position.x < targetPlayer.transform.position.x)
    //    {
    //        spriteRenderer.flipX = true;
    //        enemyRigidbody.velocity = new Vector2(3.5f, 0);
    //        moveToLeftPoint = false;
    //    }
    //}

    //public void SetTriggerPlayer(GameObject trigger)
    //{
    //    targetPlayer = trigger;
    //    if (trigger != null)
    //    {
    //        animator.SetBool("Walk", false);
    //        animator.SetBool("Run", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("Run", false);
    //        animator.SetBool("Walk", true);
    //    }
    //}
}