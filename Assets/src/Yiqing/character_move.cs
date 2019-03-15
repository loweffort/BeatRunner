//Character move left or right
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    bool goingLeft = false;
    bool goingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            goingRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            goingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            goingLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            goingLeft = false;
        }

        if (goingLeft && transform.position.x > -45)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-30, GetComponent<Rigidbody>().velocity.y, 0);
        }
        else if(goingRight && transform.position.x < 45)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(30, GetComponent<Rigidbody>().velocity.y, 0);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
        }

        GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        GetComponent<Rigidbody>().AddForce(0, -200, 0);
    }

}
