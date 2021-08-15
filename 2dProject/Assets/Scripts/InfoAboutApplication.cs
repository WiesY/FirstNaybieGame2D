using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class InfoAboutApplication
{
    public int money = 0;                          // Количество монет
    public int selectedSkin = 0;                   // Текущий выбранный скин
    public bool[] purchasedSkins = new bool[4];    // Купленные скины
    public bool[] openIslands = new bool[7];       // Открытые острова
    public bool[] openLevels = new bool[56];       // Открытые уровни

    public static int Money = 0;                          // Количество монет
    public static int SelectedSkin = 0;                   // Текущий выбранный скин
    public static bool[] PurchasedSkins = new bool[4];    // Купленные скины
    public static bool[] OpenIslands = new bool[7];       // Открытые острова
    public static bool[] OpenLevels = new bool[56];       // Открытые уровни


    public static InfoAboutApplication CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<InfoAboutApplication>(jsonString);
    }
}