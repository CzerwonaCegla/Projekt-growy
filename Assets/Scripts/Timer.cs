using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeToAdd = 10f;
    [SerializeField] private float remainingTime = 10f;

    [SerializeField] GameObject LoseScreen;
    [SerializeField] TextMeshProUGUI tmpTimerText;

    private float timeFade = 1;

    private void Start()
    {
        EventManager.current.onTimePickupTriggered += TimePickupTriggered;
        LoseScreen.SetActive(false);
    }
    void Update()
    {
        if (remainingTime > 0)
        {
            Debug.Log(remainingTime);
            remainingTime -= Time.deltaTime;
            float rounded = (float)Math.Round(remainingTime, 2);
            tmpTimerText.text = rounded.ToString() + "s";
        }
        else if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            tmpTimerText.text = remainingTime.ToString() + "s";

            if (timeFade > 0.1f)
            {
                Time.timeScale = timeFade;
                timeFade -= Time.deltaTime;
            }
            else
            {
                LoseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void TimePickupTriggered()
    {
        remainingTime += timeToAdd;
    }
}