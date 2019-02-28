using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follower : MonoBehaviour
{
    [SerializeField]
    float smootheSpeed;

    [SerializeField]
    Transform player;

    [SerializeField]
    Vector3 offset;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smootheSpeed * Time.fixedDeltaTime);

        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}
