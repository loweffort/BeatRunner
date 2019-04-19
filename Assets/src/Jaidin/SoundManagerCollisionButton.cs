using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerCollisionButton : MonoBehaviour
{
    public void startCollisionTest()
    {
        Debug.Log("starting test");
        SceneManager.LoadScene(sceneName: "SoundManagerCollisionTest");
    }
}
