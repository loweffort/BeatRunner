using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRBCMODE : HUD
{
    // Start is called before the first frame update
    void StartCycle()
    {// Press B for God Mode

        ResetScore();
    }
    // Replace Base Case with the override asto enable BC Mode
    // This is an example of Inheritance
    public override void ResetScore()
    {
        FHScore = PlayerScore;
        PlayerScore = 0;
        Multiplier = 999;
        ActiveButton = true;
        ActiveButton2 = false;
        //Multiplier = TestInc + 5000000;
        //TestInc = Multiplier;
        base.ResetScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
