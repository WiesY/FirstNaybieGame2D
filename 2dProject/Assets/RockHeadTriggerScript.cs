using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.childCount == 2)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
