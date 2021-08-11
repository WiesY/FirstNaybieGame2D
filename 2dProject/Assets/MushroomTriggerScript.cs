using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTriggerScript : MonoBehaviour
{
    private MushroomScript mushroomScript;

    private void Awake()
    {
        mushroomScript = transform.GetChild(0).GetComponent<MushroomScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mushroomScript.SetTriggerPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mushroomScript.SetTriggerPlayer(null);
        }
    }
}