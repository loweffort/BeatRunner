using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterboundarytest3 : MonoBehaviour
{
    public void startBoundaryTest()
    {
        Debug.Log("characterboundarytest3 load");
        SceneManager.LoadScene(sceneName: "YM-boundary-test3");
    }
}
