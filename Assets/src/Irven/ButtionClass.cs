using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtionClass : MonoBehaviour
{
    private UnityEngine.AudioSource buttonSound;
    private UnityEngine.AudioClip sound;
    public virtual void switchScene()
    {
        Debug.Log("Switch scene");

    }


    public void playSound()
    {
        Debug.Log("playing sound");
        buttonSound.PlayOneShot(sound);

    }

    public void setAudioSource(AudioSource givenSource)
    {
        Debug.Log("setting sound");
        buttonSound = givenSource;
        sound = buttonSound.clip;
    }


}
