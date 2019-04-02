using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    public PlayerCharacter playerCharacter;
    public GameObject masterBar;
    public GameObject masterWall;
    public GameObject[] obstacles = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        SetObstacles();
        playerCharacter.name = "playerCharacter";
    }

    private void SetObstacles()
    {
        switch (Random.Range(0, 2))
        {
            case (0):
                obstacles[0] = (GameObject)Instantiate(masterWall, new Vector3(33, 18, 850), new Quaternion(0, 0, 0, 1));
                obstacles[1] = (GameObject)Instantiate(masterBar, new Vector3(0, 6, 850), new Quaternion(0, 0, 0, 1));
                obstacles[2] = (GameObject)Instantiate(masterBar, new Vector3(-33, 6, 850), new Quaternion(0, 0, 0, 1));
                break;
            case (1):
                obstacles[0] = (GameObject)Instantiate(masterBar, new Vector3(33, 6, 850), new Quaternion(0, 0, 0, 1));
                obstacles[1] = (GameObject)Instantiate(masterWall, new Vector3(0, 18, 850), new Quaternion(0, 0, 0, 1));
                obstacles[2] = (GameObject)Instantiate(masterBar, new Vector3(-33, 6, 850), new Quaternion(0, 0, 0, 1));
                break;
            case (2):
                obstacles[0] = (GameObject)Instantiate(masterBar, new Vector3(33, 6, 850), new Quaternion(0, 0, 0, 1));
                obstacles[1] = (GameObject)Instantiate(masterBar, new Vector3(0, 6, 850), new Quaternion(0, 0, 0, 1));
                obstacles[2] = (GameObject)Instantiate(masterWall, new Vector3(-33, 18, 850), new Quaternion(0, 0, 0, 1));
                break;
        }
        for (int i = 0; i < 3; i++)
        {
            obstacles[i].name = "badObstacle";
        }
    }

    private void DestroyObstacles()
    {
        for (int i = 0; i < 3; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    private void RestartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("resetting obstacles");
            obstacles[i].transform.position = new Vector3(0, 6, -5000);
            obstacles[i].transform.rotation = new Quaternion(0, 0, 0, 1);
            obstacles[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -400);
            obstacles[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        DestroyObstacles();
        SetObstacles();
        playerCharacter.transform.position = new Vector3(25, 5, 80); //must be the same as the starting position
        playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
        playerCharacter.SendMessage("ResetYVelocity", 0.5f, SendMessageOptions.RequireReceiver);
        hud.SendMessage("ResetScore", 0.5f, SendMessageOptions.RequireReceiver);
        soundManager.StopMusic();
        soundManager.BeginMusic();
    }

    private void WonGame()
    {
        RestartGame();
        SceneManager.LoadScene(sceneName: "Menu");
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            obstacles[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -400);
            obstacles[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        if (obstacles[0].transform.position.z < 0)
        {
            DestroyObstacles();
            SetObstacles();
        }
    }
}
