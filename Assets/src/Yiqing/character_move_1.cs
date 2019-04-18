using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Character move left or right
public class character_move_1 : MonoBehaviour
{
	//use to lock movement
    private bool goingLeft = false;
    private bool goingRight = false;
    private bool initJump = false;

    // binding command
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode jump = KeyCode.Space;
    private KeyCode slide = KeyCode.S;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    //singleton
    private static character_move_1 instance = null;
    private static readonly object padlock = new object();
    private character_move_1() 
    { 

    }
    //only use in instance of character controller 
    private static character_move_1 Instance
    {
        get {
            if(instance != null)
            {
                return instance;
            }
            lock(padlock)
            {
            //If instance is not exist instantiate            	
                if(instance == null)
                {
                    instance = new character_move_1();
                }
                return instance;
            }
        }
    }

    // Virtual use to reset and initialize the check movement boolen value
    public virtual void Setup()
    {
    	goingLeft = false;
    	goingRight = false;
    	initJump = false;
    }

    void Update()
    {
    	//movement input is true, give true value to each bool value
    	//left boundary -10 right boundary 50
        // input jump and the character height 5.5
        //when jump cannot slide
        if (Input.GetKeyDown(right) && transform.position.x < 50)
        {
            goingRight = true;
        }
        else if (Input.GetKeyUp(right))
        {
            goingRight = false;
        }

        if (Input.GetKeyDown(left) && transform.position.x > -10)
        {
            goingLeft = true;
        }
        else if (Input.GetKeyUp(left))
        {
            goingLeft = false;
        }
       /* if (Input.GetKeyUp(jump) && transform.position.y >5.4 )
        {
            initJump = true;
        }*/
    }
        // Update is called once per frame
        void FixedUpdate()
        { 
        if (goingLeft)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-60, GetComponent<Rigidbody>().velocity.y, 0); 
            // Debug.Log("Left movement sucess");
        }
        else if(goingRight)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(60, GetComponent<Rigidbody>().velocity.y, 0);
            // Debug.Log("Right movement sucess");
        }
        else
        {
            // not move without input or hit boundary
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
        }
        /*if (initJump) 
        {
        	//jump height 50
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 50, 0);
            Debug.Log("Jump sucess");
            initJump = false;
        }*/

        //add force to move
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        GetComponent<Rigidbody>().AddForce(0, -800, 0);
        }
    

}
