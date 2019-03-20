using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follower : MonoBehaviour
{
    public GameObject player;
	//public Transform player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
