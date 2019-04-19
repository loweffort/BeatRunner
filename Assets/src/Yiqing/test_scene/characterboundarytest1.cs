using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterboundarytest1 : MonoBehaviour
{
    public void startBoundaryTest()
    {
        Debug.Log("characterboundarytest1 load");
        SceneManager.LoadScene(sceneName: "YM-boundary-test1");
    }
}
