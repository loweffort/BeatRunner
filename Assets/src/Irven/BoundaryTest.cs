using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundaryTest : MonoBehaviour
{

    int testFailUpper = 2;
    int testPass = 1;
    public AudioSource song;
    float m_MySliderValue = 0.0F;
    float value = .01F;

    void startTest()
    {
        song = GetComponent<AudioSource>();
        song.Play();


    }

    void OnGUI()
    {

            
           
        //Create a horizontal Slider that controls volume levels. Its highest value is 2 and lowest is 0
        m_MySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), m_MySliderValue, 0.0F, 2.0F);
        //Makes the volume of the Audio match the Slider value
        song.volume = m_MySliderValue ;
 

        while(testPass != testFailUpper) 
        {
          
                song.volume = m_MySliderValue + value;
                value = song.volume + value;
                Debug.Log("Current Volume test Status: Pass ");
                m_MySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), m_MySliderValue, 0.0F, 2.0F);

                // Will keep bound to .9F, unless game will crash
                if (song.volume > .9F)
                {
                    Debug.Log("Current Volume Test Status: Fail ");
                    testPass = testFailUpper;
                    break;
                    
                }

             
        }

        song.volume = 1.0F;
        m_MySliderValue = song.volume;
        m_MySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), m_MySliderValue, 0.0F, 1.0F);
        Debug.Log("Restoring Volume: 1.0F ");

    }

}
