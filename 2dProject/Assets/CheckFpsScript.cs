using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFpsScript : MonoBehaviour
{
    private Text myText;

    int accumulator = 0;
    int counter = 0;
    float timer = 0f;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    void Update()
    {
        accumulator++;
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            counter = accumulator;
            accumulator = 0;
        }
    }

    private void OnGUI()
    {
        myText.text = $"{counter}";
    }
}
