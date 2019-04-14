//jump movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_jump_1 : MonoBehaviour
{
	//private boolen
    bool initJump = false;
    //Transform player;

    // Start is called before the first frame update


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 6) // input jump and the character height < 5.6
        {
            initJump = true;
        }
    }

    void FixedUpdate()
    {
        if (initJump)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 50, 0);//jump height
            initJump = false;
        }
    }

}
