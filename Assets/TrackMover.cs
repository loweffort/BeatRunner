using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMover : MonoBehaviour
{
    Vector3 m_NewPosition;

    // Attach these in the Inspector window
    private int m_XValue = 0;
    private int m_YValue = 0;
    private int m_ZValue = 450;

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

        // Change the position depending on the vector
        transform.position = m_NewPosition;
        if (m_ZValue >= 0)
            m_ZValue = m_ZValue -20;
        else
            m_ZValue = 450;
        
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