using UnityEngine;

public class EnemyTargetScript : MonoBehaviour
{
    [SerializeField] private EnemyWalkScript enemyWalkScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyWalkScript.SetTriggerPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyWalkScript.SetTriggerPlayer(null);
        }
    }
}