using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private string playerTag = "Player";
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private CharacterHealth characterHealth;

    private bool isHit = false; 

    private void Start()
    {
        characterHealth = mainCharacter.transform.GetChild(0).GetComponent<CharacterHealth>();
    }

    private void Update()
    {
        if (isHit)
        {
           // characterHealth.TrapHit();

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isHit = true;
        } 
    }

}
