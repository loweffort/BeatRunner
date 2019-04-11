using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HSTB : MonoBehaviour
{
    public void TestGameHS()
    {
        Debug.Log("testing");
        SceneManager.LoadScene(sceneName: "JC_PlayGround");
    }
}
