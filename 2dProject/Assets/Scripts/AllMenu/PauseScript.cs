using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private IEnumerator coroutineTimer;

    private void Start()
    {
        coroutineTimer = TimerScript.timerScriptInstance.Timer();
    }

    public void PauseGame()
    {
        StopCoroutine(coroutineTimer);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        StartCoroutine(coroutineTimer);
        Time.timeScale = 1f;
    }

    public void OnChangeGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
}