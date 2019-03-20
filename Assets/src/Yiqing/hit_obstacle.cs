using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_obstacle : MonoBehaviour
{
	public GameManager theGameManager;
    // Start is called before the first frame update
    GameObject[] endgame;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "barObstacle")
        {
        	Debug.Log("Collision with "+ other.gameObject.name);
            Destroy(gameObject);
            //theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
