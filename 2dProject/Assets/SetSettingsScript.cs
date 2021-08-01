using UnityEngine;

public class SetSettingsScript : MonoBehaviour
{
    public void OnChangeGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
}
