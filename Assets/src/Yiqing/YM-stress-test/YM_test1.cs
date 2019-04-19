using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YM_test1 : MonoBehaviour
{
    public GameManager theGameManager;
    private bool iscollision = false;
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
            //Destroy(gameObject,0.5);
            Reset();
        }
        iscollision = false;   
    }

    private void Reset()
    {
        Instantiate(playerCharacter);
    	playerCharacter.transform.position = new Vector3(25, 5, 80); //must be the same as the starting position
       	playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    //print debug message on the screen
    void OnEnable () {
         Application.logMessageReceived += HandleLog;
     }
     
    void OnDisable () {
         Application.logMessageReceived -= HandleLog;
     }
    //print debug information in screen 
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
         //GUILayout.Label(myLog);
     }
 
}

