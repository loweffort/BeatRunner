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
        if (Input.GetKeyDown(KeyCode.Space))
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
