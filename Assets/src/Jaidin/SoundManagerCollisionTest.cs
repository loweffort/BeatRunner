using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerCollisionTest : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    bool testFail = false;
    bool testPass = false;
    int soundFrequency = 1;
    void Start(){}

    void OnGUI()
    {
        if (testFail)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test failed at sound rate of: " + soundFrequency);
        }
        if (testPass)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test passed, reaching 60 simultanious sounds");

        }
    }

    private void Update()
    { 

        if(!testFail && !testPass)
        {
            soundFrequency++;
            for(int i = 0; i < soundFrequency; i++)
            {
                Debug.Log("sound");
                soundManager.SoundOnCollision();
            }
            if(!soundManager.collisionSource.isPlaying)
            { //checks for sound playing immediately after starting to play the required sounds
                testFail = true;
            }
        }
        if(soundFrequency > 60 && !testFail)
        {
            testPass = true;
        }
    }
}
