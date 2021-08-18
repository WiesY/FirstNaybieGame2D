using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadScript : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Debug.Log(1);
    //        CharacterHealth.characterHealthInstance.HitWithMaxDamage();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.transform.position.y + 1 < transform.position.y)
        {
            CharacterHealth.characterHealthInstance.HitWithMaxDamage();
        }
    }
}
