﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
}
