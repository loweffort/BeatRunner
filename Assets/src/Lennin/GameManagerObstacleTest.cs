using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerObstacleTest : MonoBehaviour
{
    public HUD hud;
    int prevTime;
    public BarObstacle[] bars = new BarObstacle[20000];
    public Vector3[] spawnPositions;
    public BarObstacle masterBar;
    private int increment = 1;

    private bool testFail = false;
    private bool toggle = false;

    // Start is called before the first frame update
    void Start()
    {
          bars[0] = (BarObstacle)Instantiate(masterBar, new Vector3(0, 6, 850), new Quaternion (0, 0, 0, 1));  
    }

    private void RestartGame()
     {
        bars[0].transform.position = new Vector3(0, 6, 850);
        bars[0].transform.rotation = new Quaternion (0, 0, 0, 1);
    }

    private void OnGUI(){
        if( testFail ){
         GUI.Label(new Rect(80 - 12, 100, 50, 50), "Test failed at " + increment + " obstacles.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( !testFail ){

        
        
        for (int i = 1; i < increment; i++){
            bars[i].setVelocity(-400);
            if (bars[i].transform.position.z < 3)
            {
                bars[i].transform.position = new Vector3(0, 6, 850+5*i);
            }

        }

        bars[0].setVelocity(-400);
        if (bars[0].transform.position.z < 3)
        {   
        for (int i =0; i < 1000; i++){
            if( increment < 20000 ){
                bars[increment] = (BarObstacle)Instantiate(masterBar, new Vector3(0, 6, 850+5*increment), new Quaternion (0, 0, 0, 1));  
                increment++;
            }

        }
            toggle = true;
            bars[0].transform.position = new Vector3(0, 6, 850);
            }
        }
        if( increment == 20000 && !testFail ){
            Debug.Log("Test Passed");
        }

        if((int)(1.0f / Time.smoothDeltaTime) < 20 && toggle){
            testFail = true;
            Debug.Log("Test failed at " + increment + " obstacles." );
                    for ( int i = 0; i < increment; i++ ){
            bars[i].transform.position = new Vector3(0, 6, -(850+5*i));
        }
        }


    }
}
