using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public string _name;
    public double _score;
    public double _multiplier;

    public string Name
    {
        // Get name of user
        get { return _name; }
        set
        {
            _name = value;
            Console.WriteLine("Name: " + _name);
        }
    }
    // Gets or sets phone

    public double Score
    {
        get { return _score;  }
        set

        {
            _score = value;
            Console.WriteLine("Score: " + _score);
        }
    }

    // Gets or sets budget

    public double Multiplier
    {
        get { return _multiplier; }
        set

        {
            _multiplier = value;
            Console.WriteLine("Multiplier: " + _multiplier);
        }
    }

    // Stores memento

    public Momento2 SaveMemento()
    {
        Console.WriteLine("\nSaving state --\n");
        return new Momento2(_name, _score, _multiplier);
    }


    // Restores memento
    public void RestoreMemento(Momento2 memento)
    {
        Console.WriteLine("\nRestoring state --\n");
        this.Name = memento.Name;
        this.Score = memento.Score;
        this.Multiplier = memento.Multiplier;
        
    }
}
 

