using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtionClass : MonoBehaviour
{
    private UnityEngine.AudioSource buttonSound;
    private UnityEngine.AudioClip sound;

    // Alow to overide base class 
    // Virtual: use extended class version
    // abstract: extended must have a new version
    public virtual void switchScene()
    {
        Debug.Log("Switch scene");

    }


    public void playSound()
    {
        Debug.Log("playing sound");
        buttonSound.PlayOneShot(sound);

    }

    // Attach sound to audiosource
    public void setAudioSource(AudioSource givenSource)
    {
        Debug.Log("setting sound");
        buttonSound = givenSource;
        sound = buttonSound.clip;
    }


}
