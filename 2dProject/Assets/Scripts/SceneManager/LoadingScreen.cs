using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadMenu;

    private int lastScene = 0;

    public void LoadPreviousScene()
    {
        LoadNewScene(lastScene);
    }

    public void LoadNewScene(int sceneID)
    {
        lastScene = SceneManager.GetActiveScene().buildIndex;
        loadMenu.SetActive(true);
        StartCoroutine(LoadingScr(sceneID));
    }

    IEnumerator LoadingScr(int sceneID)
    {
        var slider = loadMenu.transform.Find("Slider").GetComponent<Slider>();

        AsyncOperation load = SceneManager.LoadSceneAsync(sceneID);
        while(!load.isDone)
        {
            float progress = load.progress / .9f;
            slider.value = progress;
            yield return null;
        }
    }
}
