using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterstresstest : MonoBehaviour
{
    public void startStressTest()
    {
        Debug.Log("characterstresstest load");
        SceneManager.LoadScene(sceneName: "ship-stress-test1");
    }
}
