using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonTargetScript : MonoBehaviour
{
    private ChameleonScript chameleonScript;

    private void Awake()
    {
        chameleonScript = transform.GetChild(0).GetComponent<ChameleonScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chameleonScript.SetTriggerPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chameleonScript.SetTriggerPlayer(null);
        }
    }
}