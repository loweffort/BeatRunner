using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptMemento : MonoBehaviour
{
    static void Main(string[] args)
    {
        Originator<string> orig = new Originator<string>();

        orig.SetState("state0");
      //  Caretaker<string>.SaveState(orig); //save state of the originator
        orig.ShowState();

        //restore state of the originator
     //   Caretaker<string>.RestoreState(orig, 0);
        orig.ShowState();  //shows state0
    }
}



