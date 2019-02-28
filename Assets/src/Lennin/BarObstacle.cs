using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setVelocity(int velocity)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, velocity);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
