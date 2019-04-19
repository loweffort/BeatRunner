using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charactertest : MonoBehaviour
{
    public void startTest()
    {
        Debug.Log("characters movement test load");
        SceneManager.LoadScene(sceneName: "YM_other_test1");
    }
}
