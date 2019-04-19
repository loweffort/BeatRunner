using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Main purpose is storing the origanl state of the game for undoing DRBC mode
// Also to be used for future implmenebtation of the High Score Server.
namespace GoFM
{

    public class Attmept2M : MonoBehaviour
    {
        static void Main()
        {


            Player s = new Player();
            s.Name = "Player 1";
            s.Score = 0;
            s.Multiplier = 1;

            // Time to store the internal state of things
            PlayerMemory m = new PlayerMemory();
            m.Memento = s.SaveMemento();

            if (Input.GetKeyDown(KeyCode.B))
            {
                // Store DR.BC Mode Defaults
                s.Name = "DR.BC(GOD)";
                s.Score = 0;
                s.Multiplier = 999;
            }


            // Press P to retsore Default
            if (Input.GetKeyDown(KeyCode.P))
            {
                // Restore Saved state
                s.RestoreMemento(m.Memento);
            }

            // Always waiting of a nique keybind from user
            Console.ReadKey();

        }
    }

}
