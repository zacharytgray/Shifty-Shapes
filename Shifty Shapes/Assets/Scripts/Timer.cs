using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeRemaining;
    public bool timerIsRunning = false;
    public TMP_Text timeText;

    void Start() {

        timeRemaining = PlayerPrefs.GetInt("timeLimit");
        timerIsRunning = true;

    }



    void Update()
    {

        if (timerIsRunning)
        {
            // print(timeRemaining);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                // print("Time remaining (Timer.cs): " + timeRemaining);

                PlayerPrefs.SetFloat("timeRemaining", timeRemaining);
                DisplayTime(timeRemaining);
                
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}