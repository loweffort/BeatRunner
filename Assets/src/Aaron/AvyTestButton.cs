using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvyTestButton : MonoBehaviour
{
    public void testGame()
    {
        Debug.Log("testing");
        SceneManager.LoadScene(sceneName: "Testing");
    }
}
