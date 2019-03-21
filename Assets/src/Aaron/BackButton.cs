using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void goToMenu()
    {
        Debug.Log("back");
        SceneManager.LoadScene(sceneName: "Menu");
    }
}