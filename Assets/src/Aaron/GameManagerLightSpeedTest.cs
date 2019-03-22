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
    // Start is called before the first frame update
    void Start()
    {
        prevTime = (int)Time.time;
        barObstacle.name = "barObstacle";
    }

    private void RestartGame()
     {
        barObstacle.transform.position = new Vector3(0, 6, 850);
        barObstacle.transform.rotation = new Quaternion (0, 0, 0, 1);
        playerCharacter.transform.position = new Vector3(0, 6, 4);
        playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
        playerCharacter.SendMessage("ResetVelocity", 0.5f, SendMessageOptions.RequireReceiver);
        hud.SendMessage("ResetScore", 0.5f, SendMessageOptions.RequireReceiver);
        soundManager.StopMusic();
        soundManager.BeginMusic();
    }
    // Update is called once per frame
    void Update()
    {
        int newTime = (int)Time.time;
        if (prevTime < newTime)
        {
            speedIncrement++;
            prevTime = newTime;
        }
        barObstacle.setVelocity(0 - 100 * speedIncrement);
        if (barObstacle.transform.position.z < 3)
        {
            barObstacle.transform.position = new Vector3(0, 6, 850);
        }
   }
}
