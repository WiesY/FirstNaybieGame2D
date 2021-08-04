using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapScript : MonoBehaviour
{
    private Animator animator;

    private bool hitFire;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hitFire)
        {
            animator.SetTrigger("Hit");
            Invoke("ActivatedFire", 1);
            hitFire = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && animator.GetBool("Fire"))
        {
            CharacterHealth.characterHealthInstance.TrapHit();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("DeactivatedFire", 1.5f);
        }
    }

    private void ActivatedFire()
    {
        animator.SetBool("Fire", true);
    }

    private void DeactivatedFire()
    {
        animator.SetBool("Fire", false);
        hitFire = false;
    }
}