using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject settingsMenu;

    public void OnPlayButton() // Кнопка ИГРАТЬ
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Загрузка сцены с картой уровней
    }

    public void OnStoreButton() // Кнопка МАГАЗИН
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    public void OnSettingsButton() // Кнопка НАСТРОЙКИ
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnBackButton()
    {
        mainMenu.SetActive(true);
        storeMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }
}