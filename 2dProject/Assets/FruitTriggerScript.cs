using UnityEngine;

public class FruitTriggerScript : MonoBehaviour
{
    [SerializeField] private int priceFruit = 5;

    private Animator fruitAnimator;

    private bool isTrigger = false;

    private void Awake()
    {
        fruitAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTrigger)
        {
            isTrigger = true;
            fruitAnimator.SetTrigger("Collect");
            FruitsScript.fruitScriptInstance.PickUpFruit(priceFruit);
            Destroy(gameObject, 0.1f);
        }
    }
}