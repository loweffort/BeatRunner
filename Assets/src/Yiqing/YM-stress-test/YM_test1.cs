using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YM_test1 : MonoBehaviour
{
    public GameManager theGameManager;
    private bool iscollision = false;
    private bool check = false;
    public GameObject playerCharacter;
    string myLog;
    Queue myLogQueue = new Queue();
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "badObstacle")
        {
            Debug.Log("Collision Sucess");
            iscollision = true;
            Endgame();
        }

    }

    //hit obsticale end the game
    private void Endgame()
    {
        if(iscollision)
        {
            //Destroy(gameObject,0.5f);
            Reset();
        }
    }

    private void Reset()
    {
        Instantiate(playerCharacter);
    	playerCharacter.transform.position = new Vector3(25, 5, 80); //must be the same as the starting position
       	playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
       	GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        check = true;
        Debug.Log("Load Character Sucess");

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    //print debug message on the screen
    void OnEnable () 
    {
         Application.logMessageReceived += HandleLog;
     }
     
    void OnDisable () 
    {
         Application.logMessageReceived -= HandleLog;
     }
    //print debug information in screen 
    void HandleLog(string logString, string stackTrace, LogType type)
    {
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
    void OnGUI () 
    {
         //GUILayout.Label(myLog);
        if(iscollision)
        {
            GUI.Label(new Rect(80 - 12, 30, 100, 100), "Collision sucess");
        }
        if(check)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "intial sucess");
            //check = false;
        }
    }
 
}

