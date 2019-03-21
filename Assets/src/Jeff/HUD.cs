using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : SoundManager
{
    // Player Score Variable
    public static int PlayerScore = 0;
    public static int Multiplier = 1;
    // Later to be fed in by the Music Manager
    public GUISkin layout;
    // Will Change later depending on Naming conventions
    //GameObject theChar;
    // Will Change later depending on Naming conventions
    GameObject theMenu;
    // Will Change later depending on Naming conventions
    public GameManager theGameManager;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        // This causes my Class to look for the Character.
        //theChar = GameObject.FindGameObjectWithTag("Character");
        
    }

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
        if (GUI.Button(new Rect(Screen.width - 125, 20, 120, 15), "Menu"))
        {
            GUI.Label(new Rect(Screen.width - 90, 20, 100, 15), "Menu Not Working Yet");
        }

        if (GUI.Button(new Rect(Screen.width - 125, 35, 120, 15), "Restart"))
        {
            // Player Score Returns to 0
            PlayerScore = 0;
            // This will send the RestartGame function to the Game Manager, I forgot who controls this.
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        //if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 0, 0), "Menu"))
        //{ 
        // This will send the DisplayerMenu function to the Menu Manager
        //    theGameManager.SendMessage("DisplayMenu", 0.5f, SendMessageOptions.RequireReceiver);
        //}

        // This is where I need to figure out how to A. Display when to say winner, send to a f(x)
        // for high score comparisons, for now I will just see if we can get the score and song seconds
        // to match in order to trigger my desired functions
        if (PlayerScore == SongDuration)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Wow, You are Fast!");
        }

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer % 60 == 0);
            PlayerScore += Multiplier;
        
    }
}