﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debree3 : MonoBehaviour
{
    Vector3 m_NewPosition;

    // Attach these in the Inspector window
    private int m_XValue = 250;
    private int m_YValue = 40;
    private int m_ZValue = 50;

    // Use this for initialization
    void Start()
    {
        // Initialise the vector
        m_NewPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }
    void Update()
    {
       
        // Change the NewPosition Vector's x and y components
        m_NewPosition.x = m_XValue;
        m_NewPosition.y = m_YValue;
        m_NewPosition.z = m_ZValue;

        // Change the position depending on the vector m_ZValue beleow is speed, Bigger Negative number means faster
        transform.position = m_NewPosition;
        if (m_XValue >= -350)
            m_XValue = m_XValue -1;
        else
            m_XValue = 100;
        
    }

    //public float speed = 5f;
    //public int speed = 5;

   // void Update()
   // {

        // transform.Rotate(Vector3.up, speed * Time.deltaTime);
        //RectTransform.rotation =  += speed * Time.deltaTime;
        // Quaternion.AngleAxis(Mathf.Lerp(0f, speed, 0f), Vector3.forward);
   // }
}