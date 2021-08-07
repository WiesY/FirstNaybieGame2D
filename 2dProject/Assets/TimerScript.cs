using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static TimerScript timerScriptInstance;

    private TextMeshProUGUI timerText;

    private int timer = 0;

    private void Awake()
    {
        timerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        timerScriptInstance = this;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    protected internal IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timer++;
            timerText.text = timer.ToString();
        }
    }
}