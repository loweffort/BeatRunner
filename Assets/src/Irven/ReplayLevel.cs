using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayLevel : MonoBehaviour
{
    public void startGame()
    {
        Debug.Log("starting");
        SceneManager.LoadScene(sceneName: "DifficultySelection");
    }
}