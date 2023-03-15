using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CurrTime : MonoBehaviour
{

    public TMP_Text timeLabel;
    private float time;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        time = PlayerPrefs.GetFloat("Time");
        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay)
    {

        if (timeToDisplay == -1) {
            timeLabel.text = string.Format("TIME: N/A");
        }
        else {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeLabel.text = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);
        }

    }
}
