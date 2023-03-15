using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Difficulty : MonoBehaviour
{


    public int timeLimit = 70;

    // Start is called before the first frame update
    public void EasyMode() {
        timeLimit = 180;
        PlayerPrefs.SetInt("timeLimit", timeLimit);
        SceneManager.LoadScene(2);
    }

    public void MediumMode() {
        timeLimit = 90;
        PlayerPrefs.SetInt("timeLimit", timeLimit);
        SceneManager.LoadScene(2);
    }

    public void HardMode() {
        timeLimit = 45;
        PlayerPrefs.SetInt("timeLimit", timeLimit);
        SceneManager.LoadScene(2);
    }
}
