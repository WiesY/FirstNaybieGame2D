using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject settingsMenu;

    public Toggle[] graphicsObjects;
    public Color clr;
    public Color clrClear;

    private void Start()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void OnPlayButton() // ������ ������
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // �������� ����� � ������ �������
    }

    public void OnStoreButton() // ������ �������
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    public void OnSettingsButton() // ������ ���������
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnQuitButton() // ������ �����
    {
        Application.Quit();
    }

    public void OnBackButton() // ������ �����
    {
        mainMenu.SetActive(true);
        storeMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void OnHighGraphics(bool graphics)
    {
        if (graphics)
        {
            var tmpColor = graphicsObjects[0].colors;
            tmpColor.normalColor = clr;
            graphicsObjects[0].colors = tmpColor;

            QualitySettings.SetQualityLevel(2);
        }
        else
        {
            var tmpColor = graphicsObjects[0].colors;
            tmpColor.normalColor = clrClear;
            graphicsObjects[0].colors = tmpColor;
        }
    }

    public void OnMediumGraphics(bool graphics)
    {
        if (graphics)
        {
            graphicsObjects[1].transform.GetChild(0).GetComponent<Image>().color = new Color(94, 253, 87);
            QualitySettings.SetQualityLevel(1);
        }
        else
        {

        }
    }

    public void OnLowGraphics(bool graphics)
    {
        if (graphics)
        {
            graphicsObjects[2].transform.GetChild(0).GetComponent<Image>().color = new Color(94, 253, 87);
            QualitySettings.SetQualityLevel(0);
        }
    }
}