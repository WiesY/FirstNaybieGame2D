using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine(DelayWater());
            PlayerController.playerController.speedInWater = 0.5f;
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(DelayWater());
            Debug.Log("Exit");
        }
    }

    private IEnumerator DelayWater()
    {
        yield return new WaitForSeconds(0.67f);

        PlayerController.playerController.speedInWater = 1;
    }
}
