using System.Collections;
using UnityEngine;
using TMPro;

public class CountAttempsScript : MonoBehaviour
{
    [SerializeField] private int indexLevel = 0;

    private void Start()
    {
        InfoAboutApplication.CountAttempsOnLevels[indexLevel]++;
        GetComponent<TextMeshProUGUI>().text = $"Попытка: {InfoAboutApplication.CountAttempsOnLevels[indexLevel]}";
        GoogleServices.OpenSavedGame(true);
    }
}