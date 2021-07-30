using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject settingsMenu;

    private void Start()
    {
        QualitySettings.SetQualityLevel(0);
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

    public void OnChangeGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
}