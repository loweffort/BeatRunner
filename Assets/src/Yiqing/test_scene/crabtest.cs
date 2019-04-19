using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crabtest : MonoBehaviour
{
    public void startTest()
    {
        Debug.Log("character crab game load");
        SceneManager.LoadScene(sceneName: "crab-test");
    }
}
