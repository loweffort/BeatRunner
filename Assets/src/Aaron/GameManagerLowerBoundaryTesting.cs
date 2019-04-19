using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLowerBoundaryTesting : GameManager
{
    public GameObject masterBar;
    public GameObject masterWall;
    public GameObject[] obstacles = new GameObject[256];
    private ObstacleManager obstacleManager = new ObstacleManager();
    private int obstacleSpeed;
    private int obstacleCount;
    private float obstacleLimiter;
    bool testSuccess;
    bool testOver;
    ObstacleManagerDecorator obstacleManagerDecorator;

    // Begin singleton code - code taken from http://www.blackwasp.co.uk/Singleton.aspx and Dr. BC's Signleton presentation
    private static GameManager gameManagerInstance = null;
    private static readonly object padlock = new object();
    private GameManagerLowerBoundaryTesting() { }

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
                gameManagerInstance = new GameManagerLowerBoundaryTesting();
            }
            return gameManagerInstance;
        }
    }
    // End singleton code
    // Begin state code - code taken from http://www.blackwasp.co.uk/State.aspx
    private StateLowerBoundaryTesting currentState;
    public void Request()
    {
        currentState.Handle(this);
    }
    public StateLowerBoundaryTesting State
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
        currentState = new OpenLowerBoundaryTesting();
        //set initial count of obstacles to 0
        obstacleCount = 0;
        //create an obstacleManager
        obstacleManagerDecorator = ObstacleManagerDecorator.getInstance(obstacleManager);
        //set given character name
        playerCharacter.name = "playerCharacter";
        testSuccess = false;
        testOver = false;
        obstacleLimiter = Time.fixedTime;
        //spawn all obstacles
        GenerateObstacle();
    }

    private void GenerateObstacle()
    {
        for (int i = 0; i < 85; i++)
        {
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
            obstacleCount += 3;
        }
        for (int i = obstacleCount; i < 255; i++)
        {
            //obstacles are named so they can be recognized in a collision
            obstacles[i].name = "badObstacle";
        }
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

    private void OnGUI()
    {
        if (testOver)
        {
            if (testSuccess)
            {
                GUI.Label(new Rect(80 - 12, 50, 100, 100), "Game Manager successfully managed max obstacles on easy!");
            }
            else
            {
                GUI.Label(new Rect(80 - 12, 50, 100, 100), "Game Manager could not manage max obstacles on easy!");
            }
        }
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

    // Update is called once per frame
    void Update()
    {
        if (obstacleLimiter + 30 < Time.fixedTime){
            testOver = true;
        }
        //move all obstacles forward by set difficulty speed
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacles[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * 300);
            obstacles[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        //if the furthest set of obstacles passes the character, despawn them
        if (obstacles[254].transform.position.z < 0)
        {
            DestroyAllObstacles();
            testSuccess = true;
            testOver = true;
        }
    }
}

//abstract class for State pattern
public abstract class StateLowerBoundaryTesting
{
    public abstract void Handle(GameManagerLowerBoundaryTesting context);
    public abstract int getObstacleLayout();
}

//initial state class
public class OpenLowerBoundaryTesting : StateLowerBoundaryTesting
{
    public override void Handle(GameManagerLowerBoundaryTesting context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 3))
        {
            case (0):
                context.State = new LeftLowerBoundaryTesting();
                break;
            case (1):
                context.State = new MiddleLowerBoundaryTesting();
                break;
            case (2):
                context.State = new RightLowerBoundaryTesting();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 3;
    }
}

//last low bar spawned Left class
public class LeftLowerBoundaryTesting : StateLowerBoundaryTesting
{
    public override void Handle(GameManagerLowerBoundaryTesting context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 2))
        {
            case (0):
                context.State = new MiddleLowerBoundaryTesting();
                break;
            case (1):
                context.State = new RightLowerBoundaryTesting();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 1;
    }
}

//last low bar spawned Middle class
public class MiddleLowerBoundaryTesting : StateLowerBoundaryTesting
{
    public override void Handle(GameManagerLowerBoundaryTesting context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 2))
        {
            case (0):
                context.State = new LeftLowerBoundaryTesting();
                break;
            case (1):
                context.State = new RightLowerBoundaryTesting();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 0;
    }
}

//last low bar spawned Right class
public class RightLowerBoundaryTesting : StateLowerBoundaryTesting
{
    public override void Handle(GameManagerLowerBoundaryTesting context)
    {
        //determine new obstacle orientation
        switch (Random.Range(0, 2))
        {
            case (0):
                context.State = new LeftLowerBoundaryTesting();
                break;
            case (1):
                context.State = new MiddleLowerBoundaryTesting();
                break;
        }
    }
    public override int getObstacleLayout()
    {
        return 2;
    }
}