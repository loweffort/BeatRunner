using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void RestartGame()
    {
        soundManager.StopMusic();
        soundManager.BeginMusic();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
