using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Image Fader;
    public float durationSeconds = 20 * 60;

    void Update()
    {
        float dayNightTimer = Mathf.PingPong(Time.time / durationSeconds, 1);
        Fader.color = new Vector4(0, 0, 0, dayNightTimer);
    }
}
