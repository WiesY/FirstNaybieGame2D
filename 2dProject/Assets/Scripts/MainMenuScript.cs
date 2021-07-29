using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject settingsMenu;

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
}
