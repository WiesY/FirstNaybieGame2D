using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour
{
    public Sprite[] allSkins; // Массив из существующи
    public Image[] imageForViewSkins;

    private int currSkinIndex = 0;
    
    void Start()
    {
        UpdateSkinsMenu(allSkins.Length - 1, 0, 1);
    }

    public void OnPrevSkins()
    {
        if (currSkinIndex - 1 < 0)
        {
            currSkinIndex = allSkins.Length - 1;
            UpdateSkinsMenu(currSkinIndex - 1, currSkinIndex, 0);
        }
        else
        {
            currSkinIndex--;
            UpdateSkinsMenu((currSkinIndex == 0) ? allSkins.Length - 1 : currSkinIndex - 1, currSkinIndex, currSkinIndex + 1);
        }
    }

    public void OnNextSkins()
    {
        if (currSkinIndex + 1 >= allSkins.Length)
        {
            currSkinIndex = 0;
            UpdateSkinsMenu(allSkins.Length - 1, currSkinIndex, currSkinIndex + 1);
        }
        else
        {
            currSkinIndex++;
            UpdateSkinsMenu(currSkinIndex - 1, currSkinIndex, (currSkinIndex + 1 >= allSkins.Length) ? 0 : currSkinIndex + 1);
        }
    }

    private void UpdateSkinsMenu(int first, int second, int third)
    {
        imageForViewSkins[0].GetComponent<Image>().sprite = allSkins[first];
        imageForViewSkins[1].GetComponent<Image>().sprite = allSkins[second];
        imageForViewSkins[2].GetComponent<Image>().sprite = allSkins[third];
    }
}