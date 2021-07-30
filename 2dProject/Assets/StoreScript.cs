using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreScript : MonoBehaviour
{
    public Skin[] skins;
    public Image[] imageForViewSkins;

    public TextMeshProUGUI currentMoney; // ���������� �����

    public GameObject[] buyButton; // ������ / �� ������ / ������� / ������

    public GameObject priceObject;
    public TextMeshProUGUI priceText;

    private int currSkinIndex = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SelectedSkin"))
        {
            skins[PlayerPrefs.GetInt("SelectedSkin")].choose = true;
        }
        else
        {
            skins[0].choose = true;
            PlayerPrefs.SetInt("SelectedSkin", 0);
        }
    }

    void Start()
    {
        UpdateSkinsMenu(skins.Length - 1, 0, 1);
    }

    public void OnPrevSkins()
    {
        if (currSkinIndex - 1 < 0)
        {
            currSkinIndex = skins.Length - 1;
            UpdateSkinsMenu(currSkinIndex - 1, currSkinIndex, 0);
        }
        else
        {
            currSkinIndex--;
            UpdateSkinsMenu((currSkinIndex == 0) ? skins.Length - 1 : currSkinIndex - 1, currSkinIndex, currSkinIndex + 1);
        }
    }

    public void OnNextSkins()
    {
        if (currSkinIndex + 1 >= skins.Length)
        {
            currSkinIndex = 0;
            UpdateSkinsMenu(skins.Length - 1, currSkinIndex, currSkinIndex + 1);
        }
        else
        {
            currSkinIndex++;
            UpdateSkinsMenu(currSkinIndex - 1, currSkinIndex, (currSkinIndex + 1 >= skins.Length) ? 0 : currSkinIndex + 1);
        }
    }

    private void UpdateSkinsMenu(int first, int second, int third)
    {
        imageForViewSkins[0].GetComponent<Image>().sprite = skins[first].skinSprite.GetComponent<SpriteRenderer>().sprite;
        imageForViewSkins[1].GetComponent<Image>().sprite = skins[second].skinSprite.GetComponent<SpriteRenderer>().sprite;
        imageForViewSkins[2].GetComponent<Image>().sprite = skins[third].skinSprite.GetComponent<SpriteRenderer>().sprite;

        if (skins[second].purchased && skins[second].choose)
        {
            priceObject.SetActive(false);
            foreach (var item in buyButton)
            {
                if (item.name == "Chosen Text")
                {
                    item.SetActive(true);
                    continue;
                }
                item.SetActive(false);
            }
            return;
        }
        if (skins[second].purchased && !skins[second].choose)
        {
            priceObject.SetActive(false);
            foreach (var item in buyButton)
            {
                if (item.name == "Choose Image")
                {
                    item.SetActive(true);
                    continue;
                }
                item.SetActive(false);
            }
            return;
        }
        if (!skins[second].purchased && !skins[second].choose && skins[second].skinPrice > int.Parse(currentMoney.text))
        {
            priceObject.SetActive(true);
            foreach (var item in buyButton)
            {
                if (item.name == "Cant Buy Image")
                {
                    item.SetActive(true);
                    continue;
                }
                item.SetActive(false);
            }
            return;
        }
        if (!skins[second].purchased && !skins[second].choose && skins[second].skinPrice <= int.Parse(currentMoney.text))
        {
            priceObject.SetActive(true);
            foreach (var item in buyButton)
            {
                if (item.name == "Buy Image")
                {
                    item.SetActive(true);
                    continue;
                }
                item.SetActive(false);
            }
            return;
        }
    }

    private void UpdatePlayerPrefs()
    {

    }
}

/// <summary>
/// ������ ����������� �������, ��������� �� ���������� � �����.
/// </summary>
/// <param name="skinSprite">������(����) ���������</param>
/// <param name="skinPrice">���� ���������</param>
/// <param name="purchased">������(true) ��� �� ������(false) ��������</param>
/// <param name="choose">������(true) ��� �� ������(false) ��������</param>
[System.Serializable]
public class Skin
{
    public GameObject skinSprite;
    public int skinPrice;
    public bool purchased; // ������(true) / �� ������(false)
    public bool choose; // ������(true) / �� ������(false)
}