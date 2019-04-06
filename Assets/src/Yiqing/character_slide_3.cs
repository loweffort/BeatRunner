//slide movement on x direction for crab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_slide_3 : MonoBehaviour
{
    //[SerializeField]
    float slide_speed3 = 30.0f;
    [SerializeField]
    float slide_timer3;
    float slide_angle3;
    public Transform player;

    bool slide_down;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slide_down && slide_angle3 < 0)
        {
            slide_angle3 += slide_speed3 * Time.deltaTime;
            if (slide_angle3 >= 0)
                slide_timer3 = 2;
        }
        else if (Input.GetKeyDown(KeyCode.S) && player.transform.rotation.x > 90 && player.transform.position.y < 6 || slide_angle3 > -90 && !slide_down)//get input and up boundary of ground
        {
            slide_angle3 -= slide_speed3 * Time.deltaTime;
            slide_timer3 -= Time.deltaTime;
            if (slide_timer3 <= 0)
                slide_down = true;
        }
        else if (slide_angle3 < 0)
            slide_angle3 += slide_speed3 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.S) && player.transform.position.y < 6)// make sure when jump cannot slide
        {
            slide_down = false;
            slide_timer3 = 2;
            //Debug.Log("Slide sucess");
        }
        player.transform.rotation = Quaternion.Euler(slide_angle3, 0, 0);


    }
}
