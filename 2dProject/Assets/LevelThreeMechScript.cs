using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeMechScript : MonoBehaviour
{
    [SerializeField] private GameObject _mech;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            transform.position = new Vector2(transform.position.x, 26.59f);
            _mech.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            transform.position = new Vector2(transform.position.x, 26.89f);
            _mech.SetActive(true);
        }
    }
}