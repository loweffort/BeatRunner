using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "barObstacle")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
