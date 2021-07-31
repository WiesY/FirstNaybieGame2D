using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public void OnChangeGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
}
