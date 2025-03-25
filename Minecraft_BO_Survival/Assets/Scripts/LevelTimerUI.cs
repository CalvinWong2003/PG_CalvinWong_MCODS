using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerUI : MonoBehaviour
{
    public Text timerText;
    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int mins = Mathf.FloorToInt((elapsedTime % 3600f)/ 60f);
        int secs = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, mins, secs);
    }
}
