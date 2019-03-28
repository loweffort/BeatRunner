using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_jump_1 : MonoBehaviour
{
    //public Transform player;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && transform.position.y < 6) // < 5.6
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 30, 0);
            Debug.Log("Jump sucess");
        }
        
    }

}
