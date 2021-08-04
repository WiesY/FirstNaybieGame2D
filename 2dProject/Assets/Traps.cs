using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private GameObject mainCharacter;

    private CharacterHealth characterHealth;

    private string playerTag = "Player";

    private void Start()
    {
        characterHealth = mainCharacter.transform.GetChild(0).GetComponent<CharacterHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            characterHealth.TrapHit();
        } 
    }
}