using UnityEngine;
using TMPro;

public class StoreScript : MonoBehaviour
{
    public Skin[] skins;
    private bool[] purchased;

    public TextMeshProUGUI currentMoney; // ���������� �����

    private void Awake()
    {
        purchased = InfoAboutApplication.PurchasedSkins;
        //purchased = new bool[skins.Length];
        //if (PlayerPrefs.HasKey("PurchasedSkins")) // �������� �� ��������� �����
        //{
        //    purchased = PlayerPrefsX.GetBoolArray("PurchasedSkins");
        //}
        //else
        //{
        //    purchased[0] = true;
        //}

        if (purchased[InfoAboutApplication.SelectedSkin])
        {
            skins[InfoAboutApplication.SelectedSkin].choose = true;
        }
        else
        {
            skins[InfoAboutApplication.SelectedSkin].choose = false;
            InfoAboutApplication.SelectedSkin = 0;
            skins[0].choose = true;
        }

        //if (PlayerPrefs.HasKey("SelectedSkin")) // ���� ���� ��������� ����
        //{
        //    if (purchased[PlayerPrefs.GetInt("SelectedSkin")]) // ���� ���� ��������� ���� ������
        //    {
        //        skins[PlayerPrefs.GetInt("SelectedSkin")].choose = true;
        //    }
        //    else
        //    {
        //        PlayerPrefs.SetInt("SelectedSkin", 0);
        //        skins[0].choose = true;
        //    }
        //}
        //else // ���� ��� - �������� ������ ����
        //{
        //    PlayerPrefs.SetInt("SelectedSkin", 0);
        //    skins[0].choose = true;
        //}

        currentMoney.text = InfoAboutApplication.Money.ToString();

        //if (PlayerPrefs.HasKey("Money"))
        //{
        //    currentMoney.text = PlayerPrefs.GetInt("Money").ToString();
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("Money", 0);
        //    currentMoney.text = "0";
        //}

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
        }

        UpdateStore();
    }

    private void UpdateStore()
    {
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
            if (!skins[i].purchased && !skins[i].choose && InfoAboutApplication.Money >= skins[i].skinPrice)
            {
                skins[i].buyButton[0].SetActive(true);
                skins[i].buyButton[1].SetActive(false);
                skins[i].buyButton[2].SetActive(false);
                skins[i].buyButton[3].SetActive(false);
                skins[i].priceObject.SetActive(true);
            }
            if (!skins[i].purchased && !skins[i].choose && InfoAboutApplication.Money < skins[i].skinPrice)
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
        if (InfoAboutApplication.Money >= skins[indexSkin].skinPrice && !skins[indexSkin].purchased && !skins[indexSkin].choose)
        {
            purchased[indexSkin] = true;
            InfoAboutApplication.PurchasedSkins[indexSkin] = true;
            skins[indexSkin].purchased = true;

            InfoAboutApplication.Money -= skins[indexSkin].skinPrice;
            currentMoney.text = InfoAboutApplication.Money.ToString();

            UpdateStore();

            GoogleServices.OpenSavedGame(true);
        }
    }

    public void ChooseSkin(int indexSkin)
    {
        skins[InfoAboutApplication.SelectedSkin].choose = false;

        InfoAboutApplication.SelectedSkin = indexSkin;
        skins[indexSkin].choose = true;

        UpdateStore();

        GoogleServices.OpenSavedGame(true);
    }

    public void CheatOnMoney()
    {
        InfoAboutApplication.Money += 1500;

        currentMoney.text = InfoAboutApplication.Money.ToString();

        UpdateStore();

        GoogleServices.OpenSavedGame(true);
    }
}

/// <summary>
/// ������ ����������� �������, ��������� �� ���������� � �����.
/// </summary>
/// <param name="skinObject">������ �� ����� ��������� ��������� �����(����, ����, ������)</param>
/// <param name="skinPrice">���� ���������</param>
/// <param name="purchased">������(true) ��� �� ������(false) ��������</param>
/// <param name="choose">������(true) ��� �� ������(false) ��������</param>
[System.Serializable]
public class Skin
{
    public GameObject skinObject;

    protected internal GameObject[] buyButton; // ������ ������� � ��
    protected internal GameObject priceObject; // ������ �� �������� � �����

    protected internal int skinPrice;
    protected internal bool purchased; // ������(true) / �� ������(false)
    protected internal bool choose; // ������(true) / �� ������(false)
}