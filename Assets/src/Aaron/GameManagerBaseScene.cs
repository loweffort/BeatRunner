using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBaseScene : GameManager
{
    public GameObject masterBar;
    public GameObject masterWall;
    public GameObject[] obstacles = new GameObject[256];
    private ObstacleManager obstacleManager = new ObstacleManager();
    private int obstacleSpeed;
    private int obstacleCount;
    private float obstacleLimiter;
    ObstacleManagerDecorator obstacleManagerDecorator;

    // Begin singleton code - code taken from http://www.blackwasp.co.uk/Singleton.aspx and Dr. BC's Signleton presentation
    private static GameManager gameManagerInstance = null;
    private static readonly object padlock = new object();
    private GameManagerBaseScene() { }

    public static GameManager getInstance()
    {
        if (gameManagerInstance != null)
        {
            return gameManagerInstance;
        }
        lock (padlock)
        {
            if (gameManagerInstance == null)
            {
                gameManagerInstance = new GameManagerBaseScene();
            }
            return gameManagerInstance;
        }
    }
    // End singleton code
    // Begin state code - code taken from http://www.blackwasp.co.uk/State.aspx
    private StateBase currentState;
    public void Request()
    {
        currentState.Handle(this);
    }
    public StateBase State
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
        }
    }
    // End state code
    // Start is called before the first frame update
    void Start()
    {
        //Set initial state to allow for any set of obstacles
        currentState = new Open();
        //find initial time of game to keep obstacle spawns reasonably far apart (Time given is in seconds)
        obstacleLimiter = Time.fixedTime;
        //set initial count of obstacles to 0
        obstacleCount = 0;
        //create an obstacleManager
        obstacleManagerDecorator = ObstacleManagerDecorator.getInstance(obstacleManager);
        //set given character name
        playerCharacter.name = "playerCharacter";
        //find speed based on selected difficulty
        obstacleSpeed = PlayerPrefs.GetInt("ObstacleSpeed");
    }

    private void GenerateObstacle()
    {
        //check for time of game to keep obstacle spawns reasonably far apart
        if (obstacleLimiter + 1.5 < Time.fixedTime)
        {
            //set last obstacle spawn time
            obstacleLimiter = Time.fixedTime;
            //find new obstacle configuration using the state
            currentState.Handle(this);
            //use new configuration to set obstacles
            switch (currentState.getObstacleLayout())
            {
                case (0):
                    obstacles[obstacleCount] = (GameObject)Instantiate(masterWall, new Vector3(33, 18, 850), new Quaternion(0, 0, 0, 1));
                    obstacles[obstacleCount + 1] = (GameObject)Instantiate(masterBar, new Vector3(0, 6, 850), new Quaternion(0, 0, 0, 1));
                    obstacles[obstacleCount + 2] = (GameObject)Instantiate(masterWall, new Vector3(-33, 18, 850), new Quaternion(0, 0, 0, 1));
                    break;
                case (1):
                    obstacles[obstacleCount] = (GameObject)Instantiate(masterWall, new Vector3(33, 18, 850), new Quaternion(0, 0, 0, 1));
                    obstacles[obstacleCount + 1] = (GameObject)Instantiate(masterWall, new Vector3(0, 18, 850), new Quaternion(0, 0, 0, 1));
                    obstacles[obstacleCount + 2] = (GameObject)Instantiate(masterBar, new Vector3(-33, 6, 850), new Quaternion(0, 0, 0, 1));
                    break;
                case (2):
                    obstacles[obstacleCount] = (GameObject)Instantiate(masterBar, new Vector3(33, 6, 850), new Quaternion(0, 0, 0, 1));
                    obstacles[obstacleCount + 1] = (GameObject)Instantiate(masterWall, new Vector3(0, 18, 850), new Quaternion(0, 0, 0, 1));
                    obstacles[obstacleCount + 2] = (GameObject)Instantiate(masterWall, new Vector3(-33, 18, 850), new Quaternion(0, 0, 0, 1));
                    break;
            }
            for (int i = obstacleCount; i < obstacleCount + 3; i++)
            {
                //obstacles are named so they can be recognized in a collision
                obstacles[i].name = "badObstacle";
            }
            //increment current obstacle number
            obstacleCount += 3;
        }
    }

    //Destroys a set of obstacles
    private void DestroyObstacles()
    {
        Debug.Log("Destoying Obstacles");
        for (int i = 0; i < 3; i++)
        {
            Destroy(obstacles[i]);
        }
        for (int i = 3; i < obstacleCount; i++)
        {
            obstacles[i - 3] = obstacles[i];
        }
        obstacleCount -= 3;
    }

    //Destroys all obstacles spawned by this module
    private void DestroyAllObstacles()
    {
        Debug.Log("Destoying Obstacles");
        for (int i = 0; i < obstacleCount; i++)
        {
            Destroy(obstacles[i]);
        }

        obstacleCount = 0;
    }

    //Resets field after a collision is detected
    public override void RestartGame()
    {
        soundManager.SoundOnCollision();
        DestroyAllObstacles();
        playerCharacter.transform.position = new Vector3(25, 5, 80); //must be the same as the starting position
        playerCharacter.transform.rotation = new Quaternion(0, 0, 0, 1);
        playerCharacter.SendMessage("ResetYVelocity", 0.5f, SendMessageOptions.RequireReceiver);
        hud.SendMessage("ResetScore", 0.5f, SendMessageOptions.RequireReceiver);
        soundManager.StopMusic();
        soundManager.BeginMusic();
    }

    //Will send user to end game scene
    private void WonGame()
    {
        RestartGame();
        SceneManager.LoadScene(sceneName: "Menu");
    }

    // Update is called once per frame
    void Update()
    {
        //move all obstacles forward by set difficulty speed
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacles[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * obstacleSpeed);
            obstacles[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        //if the furthest set of obstacles passes the character, despawn them
        if (obstacles[0].transform.position.z < 0)
        {
            DestroyObstacles();
        }
    }
}

//abstract class for State pattern
public abstract class StateBase
{
    public abstract void Handle(GameManagerBaseScene context);
    public abstract int getObstacleLayout();
}

//initial state class
public class Open : StateBase
{
    public override void Handle(GameManagerBaseScene context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 3))
        {
            case (0):
                context.State = new Left();
                break;
            case (1):
                context.State = new Middle();
                break;
            case (2):
                context.State = new Right();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 3;
    }
}

//last low bar spawned Left class
public class Left : StateBase
{
    public override void Handle(GameManagerBaseScene context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 2))
        {
            case (0):
                context.State = new Middle();
                break;
            case (1):
                context.State = new Right();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 1;
    }
}

//last low bar spawned Middle class
public class Middle : StateBase
{
    public override void Handle(GameManagerBaseScene context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 2))
        {
            case (0):
                context.State = new Left();
                break;
            case (1):
                context.State = new Right();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 0;
    }
}

//last low bar spawned Right class
public class Right : StateBase
{
    public override void Handle(GameManagerBaseScene context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 2))
        {
            case (0):
                context.State = new Left();
                break;
            case (1):
                context.State = new Middle();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 2;
    }
}