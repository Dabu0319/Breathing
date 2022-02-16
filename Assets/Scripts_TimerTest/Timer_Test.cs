using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Test : MonoBehaviour
{
    private bool timerActive = false;
    private float _currentTime;
    public int startMinutes;
    public Text currentTimeText;

    public Text scoreText;
    public float multiplier = 5f;
    private int _score;
    
    void Start()
    {
        _currentTime = startMinutes * 60;
    }

    
    void Update()
    {

        if (timerActive)
        {
            _currentTime = _currentTime - Time.deltaTime;
            if (_currentTime <= 0)
            {
                timerActive = false;
                Start();
                Debug.Log("Timer finished!");
            }
        }

        //score
        _score = Mathf.RoundToInt(_currentTime * multiplier);
        
        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
    
    
}
