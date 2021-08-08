using UnityEngine;

public class FruitTriggerScript : MonoBehaviour
{
    [SerializeField] private int priceFruit = 5;

    private Sprite spriteFruit;
    private Animator fruitAnimator;

    private bool isTrigger = false;

    private void Awake()
    {
        spriteFruit = GetComponent<SpriteRenderer>().sprite;
        fruitAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTrigger)
        {
            isTrigger = true;
            fruitAnimator.SetTrigger("Collect");
            FruitsScript.fruitScriptInstance.PickUpFruit(priceFruit);//, spriteFruit);
            Destroy(gameObject, 0.25f);
        }
    }
}