using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    
    private Rigidbody2D _bullet;
    [SerializeField] private float bulletSpeed = 2f;

    

    private void Awake()
    {
       _bullet = GetComponent<Rigidbody2D>();
    }

    void OnFire()
    {
        var bullet = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y - 0.4f), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * bulletSpeed, 0);
    }

}
