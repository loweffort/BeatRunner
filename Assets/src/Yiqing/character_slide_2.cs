using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_slide_2 : MonoBehaviour
{
    [SerializeField]
    float slide_speed = 3;
    float slide_timer;
    float slide_angle;
    public Transform player;

    [SerializeField]
    bool slide_up;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (slide_up && slide_angle < 0)
        {
            slide_angle += slide_speed * Time.deltaTime;
            if (slide_angle >= 0)
                slide_timer = 2;
        }
        else if (Input.GetKeyDown(KeyCode.S) && player.transform.rotation.x > 90 || slide_angle > -90 && !slide_up)
        {
            slide_angle -= slide_speed * Time.deltaTime;
            slide_timer -= Time.deltaTime;
            if (slide_timer <= 0)
                slide_up = true;
        }
        else if (slide_angle < 0)
            slide_angle += slide_speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.S))
        {
            slide_up = false;
            slide_timer = 2;
        }
        player.transform.rotation = Quaternion.Euler(slide_angle, 0, 0);


    }
}
