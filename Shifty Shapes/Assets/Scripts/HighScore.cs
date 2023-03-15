using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighScore : MonoBehaviour
{
    public TMP_Text highScoreLabel;

    void Update() {
        float highScoreValue = PlayerPrefs.GetFloat("highScoreValue");
        DisplayTime(highScoreValue);
    }

    void DisplayTime(float timeToDisplay)
    {

        if (timeToDisplay == -1) {
            highScoreLabel.text = string.Format("HIGH SCORE: N/A");
        }
        else {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            highScoreLabel.text = string.Format("HIGH SCORE: {0:00}:{1:00}", minutes, seconds);
        }

    }

    public void resetHighScore() {
         PlayerPrefs.SetFloat("highScoreValue", -1);
    }


}
