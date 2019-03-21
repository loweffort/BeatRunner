using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SliderX : MonoBehaviour
{
    private float timeRemaining;
    // 10f = 10 sec, 5f = 5 sec etc
    private const float timerMax = 200f;
    public Slider slider;


    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateSliderValue();
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            timeRemaining = timerMax;
        }

        if(timeRemaining <= 0)
        {
            timeRemaining = 0;
        }
        else if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

        }
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
    }
}
