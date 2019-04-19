using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hit_obstacle : MonoBehaviour
{
	public GameManager theGameManager;
    private bool iscollision = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "badObstacle")
        {        
            Debug.Log("Collision Sucess");
            iscollision = true;
            Endgame();
        }

    }

    //hit obsticale end the game
    private void Endgame()
    {
        if(iscollision)
        {
            Destroy(gameObject);
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            SceneManager.LoadScene(sceneName: "Menu");
        }
        iscollision = false;   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
