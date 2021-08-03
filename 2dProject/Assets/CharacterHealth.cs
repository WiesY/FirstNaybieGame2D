using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{ 
    private int healthPoints = 3;
    private string trap = "Trap";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (healthPoints > 0)
        {
            if (other.CompareTag(trap))
            {
                var hitAnim = other.GetComponent<Rigidbody2D>().velocity;
                hitAnim.y = 3;
                other.GetComponent<Rigidbody2D>().velocity = hitAnim;

                healthPoints--;
            }
        }
    }
}

