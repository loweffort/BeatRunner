using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//the object that we want to save and restore, such as a check point in an application
public class Originator<t>
{
    private t state;

    //for saving the state
    public Memento<t> CreateMemento()
    {
        Memento<t> m = new Memento<t>();
        m.SetState(state);
        return m;
    }

    //for restoring the state
    public void SetMemento(Memento<t> m)
    {
        state = m.GetState();
    }

    //change the state of the Originator
    public void SetState(t state)
    {
        this.state = state;
    }

    //show the state of the Originator
    public void ShowState()
    {
        Console.WriteLine(state.ToString());
    }
}
