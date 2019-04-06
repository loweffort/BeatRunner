//Character move left or right
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move_1 : MonoBehaviour
{
    //private boolen
    bool goingLeft = false;
    bool goingRight = false;
    //public Transform player;

    //initailize the singleton instance
    //public static character_move_1 Instance = null;
    static internal character_move_1 Instance = null; 
    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of character_move_1, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) //movement input
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
    }
        void FixedUpdate()
        { 
        if (goingLeft && transform.position.x > -10)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-60, GetComponent<Rigidbody>().velocity.y, 0); 
            //Debug.Log("Left movement sucess");
        }
        else if(goingRight && transform.position.x < 50)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(60, GetComponent<Rigidbody>().velocity.y, 0);
           // Debug.Log("Right movement sucess");
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
            // not move without input or hit boundary
        }

        //add force to move
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        GetComponent<Rigidbody>().AddForce(0, -800, 0);
        }
    

}
