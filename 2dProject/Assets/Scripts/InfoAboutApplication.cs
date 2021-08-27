using System.Collections;
using System;
using UnityEngine;

[Serializable]
public class InfoAboutApplication
{
    // Поля для сохранения
    public int money = 0;                               // Количество монет
    public int selectedSkin = 0;                        // Текущий выбранный скин
    public bool[] purchasedSkins = new bool[4];         // Купленные скины
    public bool[] openIslands = new bool[7];            // Открытые острова
    public bool[] openLevels = new bool[56];            // Открытые уровни
    public int[] countTakenFruits = new int[8];         // Количество каждых собранных фруктов
    public int[] countAttempsOnLevels = new int[56];    // Количество попыток на каждом уровне

    // Поля для доступа в других скриптах
    public static int Money = 0;                                // Количество монет
    public static int SelectedSkin = 0;                         // Текущий выбранный скин
    public static bool[] PurchasedSkins = new bool[4];          // Купленные скины
    public static bool[] OpenIslands = new bool[7];             // Открытые острова
    public static bool[] OpenLevels = new bool[56];             // Открытые уровни
    public static int[] CountTakenFruits = new int[8];          // Количество каждых собранных фруктов
    public static int[] CountAttempsOnLevels = new int[56];     // Количество попыток на каждом уровне

    public static InfoAboutApplication CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<InfoAboutApplication>(jsonString);
    }
}