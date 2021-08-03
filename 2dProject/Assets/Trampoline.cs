using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    
    private Animator animator;
    private Collision2D trampoline;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D trampoline)
    {
        if (CompareTag(playerTag))
        {
            animator.SetBool("isPlayerOn", true);
        }
    }
    private void Update()
    {
        OnCollisionEnter2D(trampoline);
        animator.SetBool("isPlayerOn", false);
    }
}
