using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timer;
    [Header("Timer Settings")]
    public float currTime;
    public bool keepTime = true;

    private void Update()
    {
        if (keepTime)
        {
            currTime = currTime += Time.deltaTime; // calculate time passed
            PrettyText();
        }
    }
    void PrettyText()
    {
        // calculating the different mesaurements for stopwatch
        string hours = Mathf.Floor(currTime / 3600).ToString("0");
        string minutes = Mathf.Floor(currTime / 60).ToString("00");
        string seconds = (currTime % 60).ToString("00");

        timer.text = hours + ":" + minutes + ":" + seconds;
    }

    public void StopTimer()
    {
        keepTime = false;
    }


}
