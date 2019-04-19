using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonEasy : MonoBehaviour
{
    public void startGame()
    {
        PlayerPrefs.SetInt("ObstacleSpeed", 300);
        SceneManager.LoadScene(sceneName: "BaseScene");
    }
}
