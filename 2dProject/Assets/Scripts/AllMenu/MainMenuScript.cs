using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        GoogleServices.text = transform.GetChild(1).gameObject.GetComponent<Text>();
        if (!GoogleServices.tryToAuthenticate) // ������ ������ ������ �����
        {
            Application.targetFrameRate = 120; // ����������� ��� �� 120
            QualitySettings.SetQualityLevel(2); // ������� ��������� �������
            GoogleServices.tryToAuthenticate = true; // �����������, ������ �� ��� ����������� ������ �����
            GoogleServices.AuthenticateAtStartApp(); // �������������� ������
        }
    }

    public void OnQuitButton() // ������ �����
    {
        GoogleServices.OpenSavedGame(true);

        // Application.Quit();
    }

    public void OnQuitButton5()
    {
        GoogleServices.OpenSavedGame(false);
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