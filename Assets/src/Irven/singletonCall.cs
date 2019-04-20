using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//singleton call to SingletonClass
public class singletonCall : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

        string updateClassName = "Analysis of Algorithms";
        SingletonClass.instance.addClassInformation(updateClassName);
    }


}
