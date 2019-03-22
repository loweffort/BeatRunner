using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMovement : MonoBehaviour
{
    //public float speed = 2f;
    public int speed = 5;

    void Update()
    {
       // transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.Rotate(0,0,speed);
    }
}