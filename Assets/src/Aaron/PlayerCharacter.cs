using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public GameManager theGameManager = GameManager.Instance;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with "+ collision.gameObject.name);
        if(collision.gameObject.name == "badObstacle")
        {
            //Please add SoundOnCollision here
            theGameManager.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }

    public void ResetYVelocity()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
    }
}
