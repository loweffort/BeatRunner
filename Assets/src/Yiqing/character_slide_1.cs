using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//slide to right for the ship slide in z direction
public class character_slide_1 : MonoBehaviour
{
    private static float slide_speed1 = 30.0f;
    [SerializeField]
    private float slide_timer1;
    private float slide_angle1;
    public Transform player;
    private bool slide_right = false;

    //binding command
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode jump = KeyCode.Space;
    private KeyCode slide = KeyCode.S;

    // Start is called before the first frame update
    void Start()
    {

    }

    //dynamic binding Virtual use to reset and initialize the check movement boolen value
    public virtual void Setup2()
    {
        slide_timer1 = 0;
        slide_angle1 = 0;
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
        //get input and up boundary of ground
        else if (Input.GetKeyDown(slide) && player.transform.rotation.z > 90 && player.transform.position.y < 6 || slide_angle1 > -90 && !slide_right) 
        {
            slide_angle1 -= slide_speed1 * Time.deltaTime;
            slide_timer1 -= Time.deltaTime;
            if (slide_timer1 <= 0)
                slide_right = true;
        }
        else if (slide_angle1 < 0)
            slide_angle1 += slide_speed1 * Time.deltaTime;
        // make sure when jump cannot slide and when slide cannot jump
        if (Input.GetKeyDown(slide) && player.transform.position.y < 6) 
        {
            slide_right = false;
            slide_timer1 = 2;
            Debug.Log("Slide right sucess");
        }
        player.transform.rotation = Quaternion.Euler(0, 0, slide_angle1);


    }
}
