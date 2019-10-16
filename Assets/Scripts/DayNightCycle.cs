using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Image Fader;
    float currentTime = 0;
    float durationSeconds = 20 * 60;

    void Update()
    {


        currentTime += Time.deltaTime;
        //float lerpTimer = Mathf.Lerp(0, 1, currentTime / timeToCycle);
        float lerpTimer = Mathf.PingPong(Time.time / durationSeconds, 1);
        Debug.Log(lerpTimer);
        Fader.color = new Vector4(0, 0, 0, lerpTimer);


    }
}
