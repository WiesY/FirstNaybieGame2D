using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkScript : MonoBehaviour
{
    public GameObject targetPlayer;

    private float speed;
    private GameObject[] movePoints;
    private Animator animator;

    private void Awake()
    {
        movePoints[0] = transform.parent.transform.Find("Left Point").gameObject;
        movePoints[1] = transform.parent.transform.Find("Right Point").gameObject;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, movePoints[0].transform.position) == 0)
        {
            animator.SetBool("Idle", true);
        }
    }
}