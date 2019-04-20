using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingletonClass : MonoBehaviour
{
    // Create a single instance of this class
    // Can only be called once, can be access from other objects
    public static SingletonClass instance;
    //Will be overwritten by "singleton call"
    public string currentClass = "CS-395";

    //Initializing instance
    void Awake()
    {
        instance = this;
    }

    // Add somme functionality
    public void addClassInformation(string updatedName)
    {
        currentClass = updatedName;
    
    }

    void OnGUI()
    {
        GUI.Label(new Rect(870, 20, 300, 300), "Class: " + currentClass);
    }

}
