using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        // StopCoroutine(TimerScript.timerScriptInstance.coroutineTimer);
        // TimerScript.timerScriptInstance.gameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        // StartCoroutine(TimerScript.timerScriptInstance.coroutineTimer);
        // TimerScript.timerScriptInstance.gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void OnChangeGraphics(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }
}