using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonMedium : MonoBehaviour
{
    public void startGame()
    {
        PlayerPrefs.SetInt("ObstacleSpeed", 400);
        SceneManager.LoadScene(sceneName: "BaseScene");
    }
}
