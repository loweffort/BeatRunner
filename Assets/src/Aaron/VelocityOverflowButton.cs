using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VelocityOverflowButton : MonoBehaviour
{
    public void startVelocityTest()
    {
        Debug.Log("starting test");
        SceneManager.LoadScene(sceneName: "LightSpeedTest");
    }
}
