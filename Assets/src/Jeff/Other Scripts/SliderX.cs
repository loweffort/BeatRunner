using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SliderX : MonoBehaviour
{
    private float timeRemaining = 0.0f;
    // 10f = 10 sec, 5f = 5 sec etc
    private const float timerMax = 20.0f;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
            slider.value = CalculateSliderValue();
            timeRemaining = timerMax;

        if (timeRemaining <= 0.0f)
        {
            timeRemaining = 0.0f;
        }
        else if(timeRemaining > 0.0f)
        {
            //timeRemaining -= Time.deltaTime;
            timeRemaining = timeRemaining-0.5f;
        }
    }

    float CalculateSliderValue()
    {
        
        return (timeRemaining / timerMax);
    }
}
