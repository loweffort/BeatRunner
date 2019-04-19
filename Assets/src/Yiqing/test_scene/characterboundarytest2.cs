using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterboundarytest2 : MonoBehaviour
{
    public void startBoundaryTest()
    {
        Debug.Log("characterboundarytest2 load");
        SceneManager.LoadScene(sceneName: "YM-boundary-test2");
    }
}
