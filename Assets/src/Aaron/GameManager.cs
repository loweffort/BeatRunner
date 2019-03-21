using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    public BarObstacle barObstacle;
    public PlayerCharacter playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
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
        barObstacle.setVelocity(-400);
        if (barObstacle.transform.position.z < 3)
        {
            barObstacle.transform.position = new Vector3(0, 6, 850);
        }
    }
}
