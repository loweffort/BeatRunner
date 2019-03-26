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

    string myLog;
    Queue myLogQueue = new Queue();

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

    void Update()
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


    void OnEnable () {
         Application.logMessageReceived += HandleLog;
     }
     
    void OnDisable () {
         Application.logMessageReceived -= HandleLog;
     }
 
    void HandleLog(string logString, string stackTrace, LogType type){
         myLog = logString;
         string newString = "\n [" + type + "] : " + myLog;
         myLogQueue.Enqueue(newString);
         if (type == LogType.Exception)
         {
             newString = "\n" + stackTrace;
             myLogQueue.Enqueue(newString);
         }
         myLog = string.Empty;
         foreach(string mylog in myLogQueue){
             myLog += mylog;
         }
     }
 
     void OnGUI () {
         GUILayout.Label(myLog);
     }
 
}

