using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonHard : MonoBehaviour
{
    public void startGame()
    {
        PlayerPrefs.SetInt("ObstacleSpeed", 500);
        SceneManager.LoadScene(sceneName: "BaseScene");
    }
}
