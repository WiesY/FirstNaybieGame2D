using UnityEngine;

public class EnemyTargetScript : MonoBehaviour
{
    private PigScript pigScript;

    private void Awake()
    {
        pigScript = transform.GetChild(0).GetComponent<PigScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pigScript.SetTriggerPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pigScript.SetTriggerPlayer(null);
        }
    }
}