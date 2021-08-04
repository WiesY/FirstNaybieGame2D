using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            CharacterHealth.characterHealthInstance.TrapHit();
        } 
    }
}