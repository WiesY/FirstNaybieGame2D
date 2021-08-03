using UnityEngine;

public class EnemyTargetScript : MonoBehaviour
{
    [SerializeField] private EnemyWalkScript enemyWalkScript;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(1);
        if (collision.CompareTag("Player"))
        {
            //enemyWalkScript.SetTriggerPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log(1);
        if (collision.CompareTag("Player"))
        {
            //enemyWalkScript.SetTriggerPlayer(null);
        }
    }
}