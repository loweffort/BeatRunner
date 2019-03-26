using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManagerCollisionTest : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    public BarObstacle barObstacle;
    public PlayerCharacter playerCharacter;
    bool testFail = false;

    int obstacleFrequency = 1;
    // Start is called before the first frame update
    void Start()
    {
        barObstacle.name = "barObstacle";
    }

    private void OnGUI()
    {
        if (testFail)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test failed at obstacle rate of: " + obstacleFrequency + "/s");
        }
    }

    // private void RestartGame()
    //  {
    //     //each time I restart, increase obstacles/second by 1; repeat until test failure
    //     barObstacle.transform.position = new Vector3(0, 6, 850);
    //     barObstacle.transform.rotation = new Quaternion (0, 0, 0, 1);
    //     playerCharacter.transform.position = new Vector3(22, 2, 80);
    //     playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
    //     hud.SendMessage("ResetScore", 0.5f, SendMessageOptions.RequireReceiver);
    //     soundManager.StopMusic();
    //     soundManager.BeginMusic();
    // }
    // Update is called once per frame
    void Update()
    {
      //Placeholder for test
   }
}
