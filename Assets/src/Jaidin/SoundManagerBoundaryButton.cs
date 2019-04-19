using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerBoundaryButton : MonoBehaviour
{
    public void startBoundaryTest()
    {
        Debug.Log("starting test");
        SceneManager.LoadScene(sceneName: "SoundManagerBoundaryTest");
    }
}
