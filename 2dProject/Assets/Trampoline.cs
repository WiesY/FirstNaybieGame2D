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
            isPlayerOn = true;
        }
    }
    private void Update()
    {
        if (isPlayerOn)
        {
            animator.SetBool("isPlayerOn", true);
        }
        if(!isPlayerOn)
        {
            animator.SetBool("isPlayerOn", false);
        }
        
    }
}
