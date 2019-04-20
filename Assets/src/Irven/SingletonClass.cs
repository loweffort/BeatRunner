using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingletonClass : MonoBehaviour
{

    public static SingletonClass instance;
    public string currentClass = "CS-395";
    void Awake()
    {
        instance = this;
    }

    public void addClassInformation(string updatedName)
    {
        currentClass = updatedName;
    
    }

    void OnGUI()
    {
        GUI.Label(new Rect(870, 20, 300, 300), "Class: " + currentClass);
    }

}
