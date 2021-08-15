using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        if (!GoogleServices.tryToAuthenticate) // Первый запуск первой сцены
        {
            GoogleServices.text = transform.GetChild(1).gameObject.GetComponent<Text>();
            Application.targetFrameRate = 120; // Ограничение ФПС до 120
            QualitySettings.SetQualityLevel(2); // Высокие настройки графики
            GoogleServices.tryToAuthenticate = true; // Обозначение, первый ли раз запускается первая сцена
            GoogleServices.AuthenticateAtStartApp(); // Аутентификация игрока

            GoogleServices.OpenSavedGame(false, "Money");
            GoogleServices.OpenSavedGame(false, "SkinsInfo");
            GoogleServices.OpenSavedGame(false, "OpenIslands");
            GoogleServices.OpenSavedGame(false, "OpenLevels");
        }
    }

    public void OnQuitButton() // Кнопка ВЫХОД
    {
        GoogleServices.OpenSavedGame(true, "Money");
        GoogleServices.OpenSavedGame(true, "SkinsInfo");
        GoogleServices.OpenSavedGame(true, "OpenIslands");
        GoogleServices.OpenSavedGame(true, "OpenLevels");

        // Application.Quit();
    }

    public void OnChangeGraphics(int graphicIndex)
    {
        var asd = QualitySettings.vSyncCount;
        QualitySettings.SetQualityLevel(graphicIndex);
        QualitySettings.vSyncCount = asd;
    }

    public void OnChangeFPS(int fpsIndex)
    {
        if (fpsIndex == 0)
        {
            Application.targetFrameRate = 15;
        }
        else if (fpsIndex == 1)
        {
            Application.targetFrameRate = 30;
        }
        else if (fpsIndex == 2)
        {
            Application.targetFrameRate = 60;
        }
        else if (fpsIndex == 3)
        {
            Application.targetFrameRate = 90;
        }
        else if (fpsIndex == 4)
        {
            Application.targetFrameRate = 120;
        }
    }

    public void OnChangeVSync(int vSyncIndex)
    {
        QualitySettings.vSyncCount = vSyncIndex;
    }
}