using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject settingsMenu;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Загрузка сцены с картой уровней
    }

    public void OnMarketButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Загрузка сцены с магазином
    }

    public void OnSettingsButton()
    {

    }
}
