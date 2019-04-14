using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Character move left or right and jump
public class character_move_1 : MonoBehaviour
{
    private bool goingLeft = false;
    private bool goingRight = false;
    private bool initJump = false;
    //singleton
    private static character_move_1 instance = null;
    private static readonly object padlock = new object();
    private character_move_1() 
    { 

    }

    public static character_move_1 Instance
    {
        get {
            if(instance != null)
            {
                return instance;
            }
            lock(padlock)
            {
                if(instance == null)
                {
                    instance = new character_move_1();
                }
                return instance;
            }
        }
    }

    //Command pattern
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode jump = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(right)) //movement input
        {
            goingRight = true;
        }
        else if (Input.GetKeyUp(right))
        {
            goingRight = false;
        }

        if (Input.GetKeyDown(left))
        {
            goingLeft = true;
        }
        else if (Input.GetKeyUp(left))
        {
            goingLeft = false;
        }
        if (Input.GetKeyDown(jump))
        {
            initJump = true;
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
        if (initJump && transform.position.y < 6) // input jump and the character height < 5.6
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 50, 0);//jump height
            initJump = false;
        }

        //add force to move
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        GetComponent<Rigidbody>().AddForce(0, -800, 0);
        }
    

}
