using UnityEngine;

public class BatTriggerScript : MonoBehaviour
{
    private BatScript batScript;

    private void Awake()
    {
        batScript = transform.GetChild(0).GetComponent<BatScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            batScript.SetTriggerPlayer(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            batScript.SetTriggerPlayer(null);
        }
    }
}