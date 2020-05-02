using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float gameTimer = 0;
    public int roundedTimer;
    private int seconds = 0;
    private int minutes = 0;
    private string timerUI = "ERROR"; //if the timer is undifined
    private string minutesString = "00";
    private string secondsString = "00";
    public Text timerUiText;
    public GameObject gameManager;
    public EndGame endGame;


    private int bombTimesNumber;
    private int bombTimeTime = 0;
    private int bombTimeTimeTemp;
    private int bombTimeTimeMax;
    private int bombTimeTimeDecrease;
    public GameObject bombManager;
    public BombTime_init bombtime;


    // Start is called before the first frame update
    void Start()
    {
        gameTimer = roundedTimer;
        bombTimeTimeMax = roundedTimer;
        bombTimesNumber = roundedTimer / 60; // There is a BombTime per 90s (1m30s)

            bombTimeTime = roundedTimer / bombTimesNumber;

        bombTimeTimeDecrease = bombTimeTime;
        bombTimeTime = roundedTimer - bombTimeTime;
        bombTimeTimeTemp = (bombTimeTimeMax - bombTimeTime) / 2;
        bombTimeTimeTemp = bombTimeTime + bombTimeTimeTemp;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0)
        {
            endGame.gameEnding();
        }
        roundedTimer = (int)Math.Round(gameTimer, 0);
        seconds = roundedTimer % 60;
        minutes = roundedTimer / 60;
        if (seconds < 10)
        {
            secondsString = "0" + seconds;
        }
        else
        {
            secondsString = "" + seconds;

        }
        if (minutes < 10)
        {
            minutesString = "0" + minutes;
        }
        else
        {
            minutesString = "" + minutes;
        }
        timerUI = minutesString + ":" + secondsString;
        timerUiText.text = timerUI;

        if (roundedTimer == bombTimeTimeTemp)
        {
            bombTimeTimeMax = bombTimeTime;
            bombTimeTime = bombTimeTimeMax - bombTimeTimeDecrease;
            bombTimeTimeTemp = (bombTimeTimeMax - bombTimeTime) / 2;
            bombTimeTimeTemp = bombTimeTime + bombTimeTimeTemp;
            bombTimesNumber -= 1;
            bombtime.startBombTime();
        }
    }

}
