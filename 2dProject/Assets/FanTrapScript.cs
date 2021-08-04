using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrapScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var tempVelocity = collision.GetComponent<Rigidbody2D>().velocity;
            tempVelocity.y = 17f;
            collision.GetComponent<Rigidbody2D>().velocity = tempVelocity;
        }
    }
}
