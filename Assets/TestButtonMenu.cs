using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestButtonMenu : MonoBehaviour
{
    public void testGamez()
    {
        Debug.Log("Testing HUD");
        SceneManager.LoadScene(sceneName: "JC_Test");
    }
}

