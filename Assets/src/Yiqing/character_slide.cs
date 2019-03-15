using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_slide : MonoBehaviour
{
	float slide_angle;
    bool slide_up=false;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            slide_up = true;
        }

        if(slide_up == true)
        {
            slide_angle = -45;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(slide_angle,0,0);           
        }

        if(Input.GetKeyUp(KeyCode.W) && slide_up == true)
        {
            slide_up = false; 
            slide_angle = 0;
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(slide_angle,0,0); 
        }
    }
}
