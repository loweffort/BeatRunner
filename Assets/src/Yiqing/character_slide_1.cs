using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//slide to right for the ship slide in z direction
public class character_slide_1 : MonoBehaviour
{
    //[SerializeField] //see float data in unity use to be test
    private static float slide_speed1 = 30.0f;
    [SerializeField]
    private float slide_timer1;
    private float slide_angle1;
    public Transform player;

    private bool slide_right;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (slide_right && slide_angle1 < 0)
        {
            slide_angle1 += slide_speed1 * Time.deltaTime;
            if (slide_angle1 >= 0)
                slide_timer1 = 2;
        }
        else if (Input.GetKeyUp(KeyCode.S) && player.transform.rotation.z > 90 && player.transform.position.y < 6 || slide_angle1 > -90 && !slide_right) //get input and up boundary of ground
        {
            slide_angle1 -= slide_speed1 * Time.deltaTime;
            slide_timer1 -= Time.deltaTime;
            if (slide_timer1 <= 0)
                slide_right = true;
        }
        else if (slide_angle1 < 0)
            slide_angle1 += slide_speed1 * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.S) && player.transform.position.y < 6) // make sure when jump cannot slide
        {
            slide_right = false;
            slide_timer1 = 2;
            //Debug.Log("Slide sucess");
        }
        player.transform.rotation = Quaternion.Euler(0, 0, slide_angle1);


    }
}
