using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static TimerScript TimerScriptIntance;

    private TextMeshProUGUI timerText;

    private int timer = 0;

    private void Awake()
    {
        timerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        TimerScriptIntance = this;
    }

    private void Start()
    {
        StartCoroutine(Timer());
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