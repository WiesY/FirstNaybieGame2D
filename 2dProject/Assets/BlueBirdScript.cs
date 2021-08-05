using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdScript : MonoBehaviour
{
    [SerializeField] private GameObject[] patrulPoints;

    private SpriteRenderer spriteRenderer;

    private float speed = 3.5f;
    private int pointNumber = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, patrulPoints[0].transform.position) <= 1f && pointNumber == 0)
        {
            pointNumber = 1;
            spriteRenderer.flipX = true;
        }
        else if (Vector2.Distance(transform.position, patrulPoints[1].transform.position) <= 1f && pointNumber == 1)
        {
            pointNumber = 0;
            spriteRenderer.flipX = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, patrulPoints[pointNumber].transform.position, speed * Time.fixedDeltaTime);
    }
}
