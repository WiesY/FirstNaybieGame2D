using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
        anim.SetTrigger("destroy");
    }

    private void BulletDestroy()
    {
        Destroy(bullet);
    }
}
