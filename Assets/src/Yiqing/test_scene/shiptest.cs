using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shiptest : MonoBehaviour
{
    public void startTest()
    {
        Debug.Log("character ship game load");
        SceneManager.LoadScene(sceneName: "ship-test");
    }
}
