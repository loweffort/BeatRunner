using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object that stores the historical state
public class Memento<t> : MonoBehaviour
{
    private t state;

    public t GetState()
    {
        return state;
    }

    public void SetState(t state)
    {
        this.state = state;
    }
}


