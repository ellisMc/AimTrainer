using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    //used to display the timer on the canvas of the scene
    public Text TimeText;

    //holds the value of the current time of the game
    public float GameTimer;

    public bool TimerOn = false;

    void Awake()
    {
        instance = this;
    }

    //starts the countdown process of the timer once the game has started
    void Start()
    {
        TimerOn = true;
    }

    // updates the current time of the game, whilst checking that the time has not ran out
    void Update()
    {
        if (TimerOn)
        {
            if(GameTimer > 0)
            {
                GameTimer -= Time.deltaTime;
                updateTimer(GameTimer);
            }
            else
            {
                GameTimer = 0;
                TimerOn = false;
            }
        }
    }

    // Converts the time in seconds to minutes and seconds for the text holder to read, then updates the timer on teh canvas of the screen
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    //checksum used to see wether functions dependent on the two states of the timer, in different scripts, are allowed to run
    public bool checksum()
    {
        if (TimerOn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
