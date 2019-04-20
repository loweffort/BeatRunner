using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIStressTestLoader: MonoBehaviour
{
    public void load()
    {
        SceneManager.LoadScene(sceneName: "UIBoundaryTest");
    }
}
