using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static TimerScript timerScriptInstance;

    protected internal IEnumerator coroutineTimer;

    private TextMeshProUGUI timerText;

    protected internal bool gameIsPaused = false;
    protected internal bool gameIsEnd = false;

    private int timer = 0;

    private void Awake()
    {
        timerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        timerScriptInstance = this;
    }

    private void Start()
    {
        coroutineTimer = Timer();
        StartCoroutine(coroutineTimer);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
            timerText.text = $"{timer / 60}:{(timer % 60) / 10}{timer % 10}";
            //if (gameIsEnd)
            //{
            //    yield break;
            //}
            //if (!gameIsPaused)
            //{
            //    timer++;
            //    timerText.text = $"{timer / 60}:{(timer % 60) / 10}{timer % 10}";
            //}
        }
    }
}