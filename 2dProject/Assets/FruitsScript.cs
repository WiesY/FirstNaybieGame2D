using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitsScript : MonoBehaviour
{
    public static FruitsScript fruitScriptInstance;

    private TextMeshProUGUI fruitsCountText;

    private int totalAmountOfFruits = 0;

    private void Awake()
    {
        fruitsCountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        fruitScriptInstance = this;
    }

    protected internal void PickUpFruit(int amountFruit)
    {
        totalAmountOfFruits += amountFruit;
        fruitsCountText.text = totalAmountOfFruits.ToString();
    }
}