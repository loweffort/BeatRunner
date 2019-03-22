using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_obstacle : MonoBehaviour
{
    public GameManager theGameManager;
    // Start is called before the first frame update
    //GameObject[] endgame;
    public Transform player;
    //public float turnSpeed = 90f;
    bool hit = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "barObstacle")
        {        
            Debug.Log("Collision and ROTATION");
            hit = true;
            //Destroy(gameObject);
            //theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);

        }

    }

    void Start()
    {

    }


    // Update is called once per frame
    /*void FixedUpdate()
    {
    	if(hit == true)
    	{
    		//player.transform.Rotate( -Vector3.forward, turnSpeed * Time.deltaTime);
    		player.rotation = Quaternion.Euler(0,90,-45);
    		hit = false;
    	}
    	
    }*/
}

