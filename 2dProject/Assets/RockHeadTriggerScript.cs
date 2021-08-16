using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform?.GetChild(1)?.gameObject);
    }
}
