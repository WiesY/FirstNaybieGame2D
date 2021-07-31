using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScreen : MonoBehaviour
{
    public Animator animator;

    public Slider slider;

    public int sceneID;
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.SetTrigger("loading");
        StartCoroutine(LoadingScr());
    }

    IEnumerator LoadingScr()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneID);
        while(!load.isDone)
        {
            float progress = load.progress / .9f;
            slider.value = progress;
            yield return null;
        }
    }
}
