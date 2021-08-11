using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterHealth.characterHealthInstance.TrapHit();
        }
    }
}