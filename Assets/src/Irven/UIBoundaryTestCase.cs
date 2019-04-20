using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIBoundaryTestCase: MonoBehaviour
{
    public void StartTest()
    {
        SceneManager.LoadScene(sceneName: "UIBoundaryTest");
    }
}
