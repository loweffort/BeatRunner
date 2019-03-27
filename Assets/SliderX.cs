using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SliderX : MonoBehaviour
{
    private float timeRemaining = 20f;
    // 10f = 10 sec, 5f = 5 sec etc
    private const float timerMax = 20f;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
            slider.value = CalculateSliderValue();
            timeRemaining = timerMax;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
            }
            else if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;


            }
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
    }
}
