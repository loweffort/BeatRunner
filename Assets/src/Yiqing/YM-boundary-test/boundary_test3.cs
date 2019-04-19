using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is a fail test which the character will move out of track and out of screen
public class boundary_test3 : MonoBehaviour
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

        GetComponent<Rigidbody>().velocity = new Vector3(-10, GetComponent<Rigidbody>().velocity.y, 0); 
        if(transform.position.x > -10 && transform.position.x < -9 )
        {
             Debug.Log("Left movement test on track sucess");
        }
        else if(transform.position.x < -10 )
        {
        	 Debug.Log("Left movement test out of track fail");
        	GetComponent<Rigidbody>().AddForce(0, -800, 0);
        }
    }
}
