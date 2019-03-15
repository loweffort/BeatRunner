using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && transform.position.y < 5.6)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 30, 0);
        }

    }
}
