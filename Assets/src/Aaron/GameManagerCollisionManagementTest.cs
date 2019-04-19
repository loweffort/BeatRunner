using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCollisionManagementTest : GameManager
{
    public GameObject masterBar;
    public GameObject masterWall;
    public GameObject[] obstacles = new GameObject[256];
    private ObstacleManager obstacleManager = new ObstacleManager();
    private int obstacleSpeed;
    bool collisionDetected;
    private float obstacleLimiter;
    ObstacleManagerDecorator obstacleManagerDecorator;

    //begin singleton code
    private static GameManager gameManagerInstance = null;
    private static readonly object padlock = new object();
    private GameManagerCollisionManagementTest() { }

    public static GameManager Instance
    {
        get
        {
            if (gameManagerInstance != null)
            {
                return gameManagerInstance;
            }
            lock (padlock)
            {
                if (gameManagerInstance == null)
                {
                    gameManagerInstance = new GameManagerCollisionManagementTest();
                }
                return gameManagerInstance;
            }
        }
    }
    //end singleton code
    // Start is called before the first frame update
    void Start()
    {
        GenerateObstacle();
        collisionDetected = false;
        obstacleLimiter = Time.fixedTime;
        obstacleManagerDecorator = ObstacleManagerDecorator.getInstance(obstacleManager);
        playerCharacter.name = "playerCharacter";
        obstacleSpeed = PlayerPrefs.GetInt("ObstacleSpeed");
    }

    private void GenerateObstacle()
    {
        obstacles[0] = (GameObject)Instantiate(masterWall, new Vector3(33, 18, 850), new Quaternion(0, 0, 0, 1));
        obstacles[1] = (GameObject)Instantiate(masterBar, new Vector3(0, 6, 850), new Quaternion(0, 0, 0, 1));
        obstacles[2] = (GameObject)Instantiate(masterWall, new Vector3(-33, 18, 850), new Quaternion(0, 0, 0, 1));

        for (int i = 0; i < 3; i++)
        {
            obstacles[i].name = "badObstacle";
        }
    }

    private void OnGUI()
    {
        if (collisionDetected)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Collision detected with obstacle!");
            if (GameObject.Find("badObstacle")==null)
            {
                GUI.Label(new Rect(80 - 12, 100, 100, 100), "Test passed as obstacles were destoyed!");
            }
            else
            {
                GUI.Label(new Rect(80 - 12, 100, 100, 100), "Test failed as obstacles were not destoyed!");
            }
        }
    }

    private void DestroyObstacles()
    {
        Debug.Log("Destoying Obstacles");
        for (int i = 0; i < 3; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    private void DestroyAllObstacles()
    {
        Debug.Log("Destoying Obstacles");
        for (int i = 0; i < 3; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    public override void RestartGame()
    {
        Debug.Log("Hello Restarting");
        collisionDetected = true;
        DestroyAllObstacles();
        playerCharacter.transform.position = new Vector3(25, 5, 80); //must be the same as the starting position
        playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
        playerCharacter.SendMessage("ResetYVelocity", 0.5f, SendMessageOptions.RequireReceiver);
        hud.SendMessage("ResetScore", 0.5f, SendMessageOptions.RequireReceiver);

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
            obstacles[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -500);
            obstacles[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }
}

