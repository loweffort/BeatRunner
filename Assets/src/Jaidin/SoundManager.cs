using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : SongAnalyzer
{
    public GameManager gameManager;
    private UnityEngine.AudioSource musicSource;
    private UnityEngine.AudioClip song;
    public float SongDuration;
    private UnityEngine.AudioClip collision;
    //Requires to be public to be able to tell if it is playing outside of component
    public UnityEngine.AudioSource collisionSource;

    public dynamic TimeElapsed = 0f;
    //Singleton code
    private static SoundManager soundManagerInstance = null;
    private static readonly object padlock = new object();
    private SoundManager() { }

    public static SoundManager getInstance()
    {
            if(soundManagerInstance != null)
            {
                return soundManagerInstance;
            }
            lock(padlock)
            {
                if(soundManagerInstance == null)
                {
                    soundManagerInstance = new SoundManager();
                }
                return soundManagerInstance;
            }
    }

    void Start()
    {
        //Grabs both audio sources, the first for music, the second for the collision sound.
        AudioSource[] sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        song = musicSource.clip;
        SongDuration = song.length;
        collisionSource = sources[1];
        collision = collisionSource.clip;
        BeginMusic();
        Reset();
    }   

    //Dynamically bound method. Overrides Reset from SongAnalyzer
    public override void Reset()
    {
        Debug.Log("Please");
        // StopMusic();
        // BeginMusic();
        // TimeElapsed = 0f;
    }

    public void DebugMethod()
    {
        Debug.Log("This is static on SoundManager");
    }

    //This pauses, allowing for resume at the same point from which it was paused
    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }
    public void BeginMusic()
    {
        musicSource.Play(0);
    }

    //This resets song, will start from beginning next time it is played
    public void StopMusic() 
    {
        musicSource.Stop();
    }

    public void SoundOnCollision(){
       collisionSource.PlayOneShot(collision);
    }

    void Update()
    {
        AnalyzeSong(musicSource);
        TimeElapsed += Time.deltaTime;

        if(TimeElapsed >= SongDuration) 
        {
            gameManager.SendMessage("WonGame", 0.5f, SendMessageOptions.RequireReceiver);
            // Currently this function does not exist.
            // HUD.SendMessage("SaveHS", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }
    
}
