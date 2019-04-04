using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void setVelocity(int velocity)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, velocity);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }
}
