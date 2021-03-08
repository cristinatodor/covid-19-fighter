using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    
    public float timeRemaining = 60f;
    private float timeFixed;
    public bool timerIsRunning = false;

    public float lockdowRemaining = 60f;
    private float lockdownFixed;
    public bool lockdownIsRunning = false;
    
    public Text timeText;
    public Text lockdownText;

    
    void Start() {
        timerIsRunning = true;
        timeFixed = timeRemaining;

        lockdownIsRunning = false;
        lockdownFixed = lockdowRemaining;
    }

    void Update() {

        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;

                DisplayTime(timeRemaining);
            }

            else {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                lockdownIsRunning = true;
                lockdownText.text = "Lockdown ends";
                lockdowRemaining = lockdownFixed;
            }
        }

        if (lockdownIsRunning) {
            if (lockdowRemaining > 0) {
                lockdowRemaining -= Time.deltaTime;

                DisplayTime(lockdowRemaining);
            }

            else {
                Debug.Log("Lockdown has ended");
                lockdowRemaining = 0;
                lockdownIsRunning = false;

                timerIsRunning = true;
                lockdownText.text = "Lockdown in"; 
                timeRemaining = timeFixed;

            }
        }
    }


    void DisplayTime(float timeToDisplay) {

        timeToDisplay += 1;
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
