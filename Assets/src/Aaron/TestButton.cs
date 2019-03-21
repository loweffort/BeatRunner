using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButton : MonoBehaviour
{
    public void testGame()
    {
        Debug.Log("testing");
        SceneManager.LoadScene(sceneName: "TestSelect");
    }
}
