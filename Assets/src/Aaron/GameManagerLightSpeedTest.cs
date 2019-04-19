using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLightSpeedTest : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    public BarObstacle barObstacle;
    public PlayerCharacter playerCharacter;
    int prevTime;
    int speedIncrement;
    bool testFail = false;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = SoundManager.getInstance();

        prevTime = (int)Time.time;
        barObstacle.name = "barObstacle";
    }

    private void OnGUI()
    {
        if (testFail)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test failed at a velocity of " + 100 * speedIncrement);
        }
    }

    private void RestartGame()
     {
        barObstacle.transform.position = new Vector3(0, 6, 850);
        barObstacle.transform.rotation = new Quaternion (0, 0, 0, 1);
        playerCharacter.transform.position = new Vector3(22, 2, 80);
        playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
        hud.SendMessage("ResetScore", 0.5f, SendMessageOptions.RequireReceiver);
        soundManager.StopMusic();
        soundManager.BeginMusic();
    }
    // Update is called once per frame
    void Update()
    {
        int newTime = (int)Time.time;
        if (prevTime < newTime && !testFail)
        {
            speedIncrement++;
            prevTime = newTime;
        }
        if(!testFail)
            barObstacle.setVelocity(0 - 100 * speedIncrement);
        else
        {
            barObstacle.setVelocity(0);
            barObstacle.transform.position = new Vector3(0, 6, -850);
        }
            
        if (barObstacle.transform.position.z < 3 && !testFail)
        {
            testFail = true;
            barObstacle.transform.position = new Vector3(0, 6, 850);
        }
   }
}
