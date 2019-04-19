using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManager : MonoBehaviour {
    public SoundManager soundManager;
    public HUD hud;
    public PlayerCharacter playerCharacter;

    public abstract void RestartGame();
}
