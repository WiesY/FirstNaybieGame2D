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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("destroy");
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterHealth.characterHealthInstance.EnemyHit();
        }
    }

    private void BulletDestroy()
    {
        Destroy(bullet);
    }
}
