using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManagerCollisionTest : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    public BarObstacle barObstacle;
    public PlayerCharacter playerCharacter;
    bool testFail = false;
    bool testPass = false;
    int soundFrequency = 1;
    void Start(){}
    private void OnGUI(){
        if (testFail)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test failed at sound rate of: " + soundFrequency + "/s");
        }
        if (testPass)
        {
            GUI.Label(new Rect(80 - 12, 50, 100, 100), "Test passed, reaching 1000 sounds/second");

        }
    }
     void Update(){

        // if(testFail || testPass){
        //     yield return new WaitForSeconds(5);
        //     Application.Quit();
        // }

        // if(!testFail && !testPass){
        //     soundFrequency++;
        //     // for(int i = 0; i < System.Math.Floor(Time.deltaTime/soundFrequency); i++){
        //     //     soundManager.SoundOnCollision();
        //     // }
        //     if(!soundManager.collisionSource.isPlaying){ //checks for sound playing immediately after starting to play the required sounds
        //         testFail = true;
        //     }
        // }
        // if(soundFrequency > 1000 && !testFail){
        //     testPass = true;
        // }
   }
}
