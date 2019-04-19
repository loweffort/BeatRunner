using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this test is to test the left boundary of the character, which character cannot move out of the boundary
//otherwiese, it will drop down of the track
public class boundary_test1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        if (transform.position.x > -10)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-10, GetComponent<Rigidbody>().velocity.y, 0); 
            if(transform.position.x > -10 && transform.position.x < -9 )
            {
             Debug.Log("Left movement test sucess");
            }
        }
        else if(transform.position.x < -11)
        {
        	Debug.Log("Left movement test fail");
        }
    }
}
