using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with "+ collision.gameObject.name);
        if(collision.gameObject.name == "barObstacle")
        {
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }

    public void ResetYVelocity()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
