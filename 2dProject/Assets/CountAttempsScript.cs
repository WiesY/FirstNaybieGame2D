using System.Collections;
using UnityEngine;
using TMPro;

public class CountAttempsScript : MonoBehaviour
{
    [SerializeField] private int indexLevel = 0;

    private void Awake()
    {
        InfoAboutApplication.CountAttempsOnLevels[indexLevel]++;
        GetComponent<TextMeshProUGUI>().text = $"Attempt {InfoAboutApplication.CountAttempsOnLevels[indexLevel]}";
    }
}