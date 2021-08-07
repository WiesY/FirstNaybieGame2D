using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitsScript : MonoBehaviour
{
    public static FruitsScript fruitScriptInstance;

    private Image fruitsImage;
    private TextMeshProUGUI fruitsCountText;

    private int totalAmountOfFruits = 0;

    private void Awake()
    {
        fruitsCountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        fruitsImage = transform.GetChild(0).GetComponent<Image>();
        fruitScriptInstance = this;
    }

    protected internal void PickUpFruit(int amountFruit, Sprite spriteFruit)
    {
        totalAmountOfFruits += amountFruit;
        fruitsCountText.text = totalAmountOfFruits.ToString();
        fruitsImage.sprite = spriteFruit;
    }
}