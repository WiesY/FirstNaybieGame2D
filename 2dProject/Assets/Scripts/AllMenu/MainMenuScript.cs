using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void OnQuitButton() // Кнопка ВЫХОД
    {
        Application.Quit();
    }

    public void OnChangeGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
}