using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStressTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void stressTest()
    {

        // We're going to measure the stress to the scene loading
        int pass = 1, fail = 2;
        int value = 0;
        while (pass != fail)
        {

            SceneManager.LoadScene(sceneName: "BaseScene");
            Debug.Log("Scene: Menu Scene");
            SceneManager.LoadScene(sceneName: "Menu");
            Debug.Log("Scene: Base Scene");

            value++;
            Debug.Log("Test: Passed");

            // If I go to 20 game will break & will need to "force quit"
            if (value > 10 )
            {
                Debug.Log("Test: Failed");
                pass = fail;
                break;
            }

        }

    }
}
