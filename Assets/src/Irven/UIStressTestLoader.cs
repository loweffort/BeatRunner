using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Switch scene: UIBoundaryTest
public class UIStressTestLoader: MonoBehaviour
{
    public void load()
    {
        SceneManager.LoadScene(sceneName: "UIBoundaryTest");
    }
}
