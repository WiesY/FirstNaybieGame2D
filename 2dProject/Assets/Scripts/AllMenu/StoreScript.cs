using UnityEngine;
using TMPro;

public class StoreScript : MonoBehaviour
{
    public Skin[] skins;
    private bool[] purchased;

    public TextMeshProUGUI currentMoney; // Количество монет

    private void Awake()
    {        
        purchased = new bool[skins.Length];
        if (PlayerPrefs.HasKey("PurchasedSkins")) // Проверка на купленные скины
        {
            purchased = PlayerPrefsX.GetBoolArray("PurchasedSkins");
        }
        else
        {
            purchased[0] = true;
        }

        if (PlayerPrefs.HasKey("SelectedSkin")) // Если есть выбранный скин
        {
            if (purchased[PlayerPrefs.GetInt("SelectedSkin")]) // Если этот выбранный скин куплен
            {
                skins[PlayerPrefs.GetInt("SelectedSkin")].choose = true;
            }
            else
            {
                PlayerPrefs.SetInt("SelectedSkin", 0);
                skins[0].choose = true;
            }
        }
        else // Если нет - выбираем первый скин
        {
            PlayerPrefs.SetInt("SelectedSkin", 0);
            skins[0].choose = true;
        }

        if (PlayerPrefs.HasKey("Money"))
        {
            currentMoney.text = PlayerPrefs.GetInt("Money").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
            currentMoney.text = "0";
        }

        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].buyButton = new GameObject[4];
            skins[i].buyButton[0] = skins[i].skinObject.transform.Find("Buy Button").gameObject;
            skins[i].buyButton[1] = skins[i].skinObject.transform.Find("Cant Buy Button").gameObject;
            skins[i].buyButton[2] = skins[i].skinObject.transform.Find("Choose Button").gameObject;
            skins[i].buyButton[3] = skins[i].skinObject.transform.Find("Chosen Button").gameObject;

            skins[i].priceObject = skins[i].skinObject.transform.Find("Price Info").gameObject;

            skins[i].skinPrice = int.Parse(skins[i].skinObject.transform.Find("Price Info").Find("Price Text").GetComponent<TextMeshProUGUI>().text);
            skins[i].purchased = purchased[i];

            if (PlayerPrefs.GetInt("SelectedSkin") == i)
            {
                skins[i].choose = true;
            }
        }
        UpdateStore();
    }

    private void UpdateStore()
    {
        skins[PlayerPrefs.GetInt("SelectedSkin")].choose = true;

        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].purchased && skins[i].choose)
            {
                skins[i].buyButton[0].SetActive(false);
                skins[i].buyButton[1].SetActive(false);
                skins[i].buyButton[2].SetActive(false);
                skins[i].buyButton[3].SetActive(true);
                skins[i].priceObject.SetActive(false);
            }
            if (skins[i].purchased && !skins[i].choose)
            {
                skins[i].buyButton[0].SetActive(false);
                skins[i].buyButton[1].SetActive(false);
                skins[i].buyButton[2].SetActive(true);
                skins[i].buyButton[3].SetActive(false);
                skins[i].priceObject.SetActive(false);
            }
            if (!skins[i].purchased && !skins[i].choose && PlayerPrefs.GetInt("Money") >= skins[i].skinPrice)
            {
                skins[i].buyButton[0].SetActive(true);
                skins[i].buyButton[1].SetActive(false);
                skins[i].buyButton[2].SetActive(false);
                skins[i].buyButton[3].SetActive(false);
                skins[i].priceObject.SetActive(true);
            }
            if (!skins[i].purchased && !skins[i].choose && PlayerPrefs.GetInt("Money") < skins[i].skinPrice)
            {
                skins[i].buyButton[0].SetActive(false);
                skins[i].buyButton[1].SetActive(true);
                skins[i].buyButton[2].SetActive(false);
                skins[i].buyButton[3].SetActive(false);
                skins[i].priceObject.SetActive(true);
            }
        }
    }

    public void BuySkin(int indexSkin)
    {
        if (PlayerPrefs.GetInt("Money") >= skins[indexSkin].skinPrice && !skins[indexSkin].purchased && !skins[indexSkin].choose)
        {
            purchased[indexSkin] = true;
            skins[indexSkin].purchased = true;

            currentMoney.text = (PlayerPrefs.GetInt("Money") - skins[indexSkin].skinPrice).ToString();

            PlayerPrefsX.SetBoolArray("PurchasedSkins", purchased);
            PlayerPrefs.SetInt("Money", int.Parse(currentMoney.text));

            UpdateStore();
        }
    }

    public void ChooseSkin(int indexSkin)
    {
        skins[PlayerPrefs.GetInt("SelectedSkin")].choose = false;

        skins[indexSkin].choose = true;
        PlayerPrefs.SetInt("SelectedSkin", indexSkin);

        UpdateStore();
    }

    public void CheatOnMoney()
    {
        PlayerPrefs.SetInt("Money", 5000);
        currentMoney.text = PlayerPrefs.GetInt("Money").ToString();

        UpdateStore();
    }
}

/// <summary>
/// Массив экземпляров классов, состоящий из информации о скине.
/// </summary>
/// <param name="skinObject">Объект со всеми дочерними объектами скина(скин, цена, кнопки)</param>
/// <param name="skinPrice">Цена персонажа</param>
/// <param name="purchased">Куплен(true) или не куплен(false) персонаж</param>
/// <param name="choose">Выбран(true) или не выбран(false) персонаж</param>
[System.Serializable]
public class Skin
{
    public GameObject skinObject;

    protected internal GameObject[] buyButton; // Кнопки покупки и тд
    protected internal GameObject priceObject; // Объект с иконкой и цифрой цены

    protected internal int skinPrice;
    protected internal bool purchased; // Куплен(true) / Не куплен(false)
    protected internal bool choose; // Выбран(true) / Не выбран(false)
}