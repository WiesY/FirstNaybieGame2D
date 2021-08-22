using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FruitsScript : MonoBehaviour
{
    public static FruitsScript fruitScriptInstance;

    private Image fruitsImage;
    private TextMeshProUGUI fruitsCountText;

    protected internal int totalAmountOfFruits = 0;

    private void Awake()
    {
        fruitsCountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        fruitsImage = transform.GetChild(0).GetComponent<Image>();
        fruitScriptInstance = this;
    }

    private void Start()
    {
        StartCoroutine(AnimationPickUpFruits());
    }

    protected internal void PickUpFruit(int amountFruit, int idFruit)//, Sprite spriteFruit)
    {
        totalAmountOfFruits += amountFruit;
        InfoAboutApplication.CountTakenFruits[idFruit] += 1;
        //fruitsImage.sprite = spriteFruit;        
    }

    private IEnumerator AnimationPickUpFruits()
    {
        while (true)
        {
            if (totalAmountOfFruits > int.Parse(fruitsCountText.text))
            {
                fruitsCountText.fontSize = 50;

                while (int.Parse(fruitsCountText.text) < totalAmountOfFruits)
                {
                    fruitsCountText.text = (int.Parse(fruitsCountText.text) + 1).ToString();
                    yield return new WaitForSeconds(0.05f);
                }

                yield return new WaitForSeconds(0.4f);

                while (fruitsCountText.fontSize > 36)
                {
                    fruitsCountText.fontSize -= 0.75f;
                    yield return new WaitForSeconds(0.0035f);
                }
            }

            yield return new WaitForSeconds(0.15f);
        }
    }
}