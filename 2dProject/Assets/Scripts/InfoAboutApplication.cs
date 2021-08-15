using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class InfoAboutApplication
{
    public int money = 555;   // Количество монет
    public int selectedSkin = 0;     // Текущий выбранный скин
    public bool[] purchasedSkins;    // Купленные скины
    public bool[] openIslands;       // Открытые острова
    public bool[] openLevels;        // Открытые уровни

    public static int Money = 555;   // Количество монет
    public static int SelectedSkin = 0;     // Текущий выбранный скин
    public static bool[] PurchasedSkins;    // Купленные скины
    public static bool[] OpenIslands;       // Открытые острова
    public static bool[] OpenLevels;        // Открытые уровни


    public static InfoAboutApplication CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<InfoAboutApplication>(jsonString);
    }
}