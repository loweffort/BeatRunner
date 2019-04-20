using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayLevel : ButtionClass
{
    public UnityEngine.AudioSource unitySource;
    //public UnityEngine.AudioClip unitySound;
    public override void switchScene()
    {
        setAudioSource(unitySource);
        Debug.Log("starting");
        playSound();
        SceneManager.LoadScene(sceneName: "DifficultySelection");
    }

    void Start()
    {
        Debug.Log("entering start");

    }
}