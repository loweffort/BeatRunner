using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerBoundaryTest : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    // public BarObstacle barObstacle;
    // public PlayerCharacter playerCharacter;
    bool testFail = false;
    bool testPass = false;
    int numberofSounds = 0;
    void Start(){}

    void OnGUI()
    {
        if (testFail)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test failed after: " + numberofSounds + " sounds /s");
        }
        if (testPass)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test passed, reaching 1000 sounds played consecutively");

        }
    }

    private IEnumerator Update()
    { 
        if(testFail || testPass)
        {
            yield return new WaitForSeconds(5);
            Application.Quit();
        }

        if(!testFail && !testPass)
        {
            //Should play 1000 sounds consecutively
            if(!soundManager.collisionSource.isPlaying) 
            { 
                soundManager.SoundOnCollision();
                numberofSounds++;
            }
        }
        if(numberofSounds > 1000 && !testFail)
        {
            testPass = true;
        }
    }
}
