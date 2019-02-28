using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager paddle1 = Instantiate(soundManager) as SoundManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
