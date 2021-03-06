using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] private GameObject[] destoyedObjects;
    private Rigidbody2D blockRigidbody;

    private void Start()
    {
        blockRigidbody = GetComponent<Rigidbody2D>();
        destoyedObjects[0].SetActive(false);
        destoyedObjects[1].SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (blockRigidbody.velocity.x > 5f || blockRigidbody.velocity.x < -1.95f)
        {            
            destoyedObjects[0].transform.position = new Vector2(transform.position.x, transform.position.y + 0.15f);
            destoyedObjects[1].transform.position = new Vector2(transform.position.x, transform.position.y - 0.15f);
            gameObject.SetActive(false);
            destoyedObjects[0].SetActive(true);
            destoyedObjects[1].SetActive(true);
            destoyedObjects[0].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)) * blockRigidbody.velocity.x * 430);
            destoyedObjects[1].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)) * blockRigidbody.velocity.x * 430);
        }
    }
}