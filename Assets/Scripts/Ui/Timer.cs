using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

public class Timer : MonoBehaviour
{
    public float PlayedTime;

    public float TimePlayed;
    public TMP_Text TextDisplay;
    string Show_time(float time)
    {
        int hour = Mathf.FloorToInt(time / 3600);
        int mins = Mathf.FloorToInt((time - hour * 3600) / 60);
        int sec = (int)time - hour * 3600 - mins * 60;
        return string.Format("{0,-2}:{1,-2}", mins, sec);
    }
    // Update is called once per frame
    void Update()
    {
        TextDisplay.text = "Time " + Show_time(Stats_Manager.Instance.TimePlayed);
    }
}
