using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    private bool isPlayerOn;

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            //other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50);
            animator.SetBool("IsPlayerOn", true);
            var JumpSpeed = other.GetComponent<Rigidbody2D>().velocity;
            JumpSpeed.y = 30f;
            other.GetComponent<Rigidbody2D>().velocity = JumpSpeed;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsPlayerOn", false);
    }

}
