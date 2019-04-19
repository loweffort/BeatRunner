using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public interface HUDM
//{
//    int PlayerScore { get; }
//    int Multiplier{ get; }
//}

public class HUD : SoundManager
{
    //  Player Score Variable also this is Late Binding "Dyanmic"
    //  these dynamic objects get detected and converted into System.Int32 
    //  Had to enforce API compatability under player settings to .4 from 2.0.
  
    public dynamic PlayerScore = 0;
    public dynamic Multiplier = 1;
    public bool ActiveButton = false;
    public bool ActiveButton2 = false;

    // Static Binding (Early),  the compiler already knows about what kind 
    // of object it is and what are the methods or properties it holds
    public static int TestInc = 0;
   

    // Later to be fed in by the Music Manager
    public GUISkin layout;
    // Will Change later depending on Naming conventions
    //GameObject theChar;
    // Will Change later depending on Naming conventions
    GameObject theMenu;
    // Will Change later depending on Naming conventions
    public GameManager theGameManager;
    public DRBCMODE theUpgrades;
    public Player thePlayer;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // This causes my Class to look for the Character.
        //theChar = GameObject.FindGameObjectWithTag("Character");
        
    }
    //*****************************************************************************************
    // Virtual is Used
    public virtual void ResetScore()
    {
        FHScore = PlayerScore;
        PlayerScore = 0;
        Multiplier = 1;
        ActiveButton2 = false;
        ActiveButton = true;
        //Multiplier = TestInc + 5000000;
        //TestInc = Multiplier;
    }

    //Singleton, keep high score to have only one instance at a time as you dont want multiple
    // high scores being produced in the game which if it were to be possible 
    // someone might be tempted to do injection attacks to overwrite your code and cheat.
    // Class Singleton: -SingletonIstanceL Singleton +getinstance(): Singleton ---new---> Class Singleton
    // This tyle should not be used if you need multiple instance of the high score variable,
    // Possible alternatives are a decorator but that may be better suited for DRBC mode or momento. 

    private new static HUD instance = null;
        public static HUD SharedInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HUD();
                }
                return instance;
            }
        }
    public float FHScore;
    //Singleton   
    //*****************************************************************************************

    void CollisionSifter(Collision collision)
    {
        if (collision.gameObject.name == "BarObstacle")
        {
            PlayerScore = 0;
            Multiplier = 1;
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        else if (collision.gameObject.name == "goodObstacle")
        {
            PlayerScore = PlayerScore + 50;
            Multiplier = Multiplier + 1;
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        // Postion of PlayerScore and Shape type
        GUI.Label(new Rect(80 - 12, 20, 100, 100), "" + PlayerScore);
        GUI.Label(new Rect(80 - 75, 20, 100, 100), "Score");
        GUI.Label(new Rect(80 - 12, 0, 100, 100), "" + Multiplier);
        GUI.Label(new Rect(80 - 75, 0, 100, 100), "Multi x");

        // SendMessahe call is a f(x) to trigger any f(x) that matches the name that
        // is set in the class.So, if the Player hits my menu button I want to send a signal
        // to the Menu Function to execute DisplayMenu, for now I am just seeing if we 
        // can just reset the game with score and ensure Menu Manager and Game Manager can communicate
        if (GUI.Button(new Rect(Screen.width - 125, 20, 120, 20), "Menu"))
        {
            //GUI.Label(new Rect(Screen.width - 90, 20, 100, 15), "Menu Not Working Yet");
            PlayerScore = 0;
            // This will send the RestartGame function to the Game Manager, I forgot who controls this.
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            SceneManager.LoadScene(sceneName: "Menu");
        }

        if (GUI.Button(new Rect(Screen.width - 125, 35, 120, 20), "Restart"))
        {
            // Player Score Returns to 0
            PlayerScore = 0;
            // This will send the RestartGame function to the Game Manager, I forgot who controls this.
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (ActiveButton == true)
        {
            if (GUI.Button(new Rect(Screen.width - 125, 50, 120, 20), "DR.BC") || (Input.GetKeyDown(KeyCode.B)))
            {
                // Player Score Returns to 0
                //PlayerScore = 0;
                Multiplier = 999;
                // This will send the RestartGame function to the Game Manager, I forgot who controls this.
                theUpgrades.SendMessage("StartCycle", 0.5f, SendMessageOptions.RequireReceiver);
                //button.gameObject.SetActive(false);
                //button.gameObject.SetActive(true);
                ActiveButton2 = true;
                ActiveButton = false;

            }
        }

        if (ActiveButton2 == true)
        {
            if (GUI.Button(new Rect(Screen.width - 125, 50, 120, 20), "Undo") || (Input.GetKeyDown(KeyCode.N)))
            {
                // Player Score Returns to 0
                //PlayerScore = 0;
                Multiplier = 1;
                // This will send the RestartGame function to the Game Manager, I forgot who controls this.
                thePlayer.SendMessage("RestoreMemento", 0.5f, SendMessageOptions.RequireReceiver);
                //button.gameObject.SetActive(false);
                //button.gameObject.SetActive(true);
                ActiveButton = true;
                ActiveButton2 = false;
            }
        }

        // This is where I need to figure out how to A. Display when to say winner, send to a f(x)
        // for high score comparisons, for now I will just see if we can get the score and song seconds
        // to match in order to trigger my desired functions
        //if (PlayerScore == SongDuration)
        //{
        //     GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Wow, You are Fast!");
        //}

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer % 60 == 0);
            PlayerScore += Multiplier;

        if (Input.GetKeyDown(KeyCode.N))
        {
            ActiveButton = true;
            ActiveButton2 = false;
        }
        else if
            (Input.GetKeyDown(KeyCode.B))
        {
            ActiveButton2 = true;
            ActiveButton = false;
        }
    }
}