using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public GameManager gameManager;
    public static SoundManager instance = null;
    private AudioSource musicSource;
    private AudioClip song;
    public float TimeElapsed = 0;
    public float SongDuration;
    private AudioClip collision;
    public AudioSource collisionSource;
    private float[] spectrum = new float[2048];
    private float[] prevspectrum = new float[2048];
    private float[] prevprevspectrum = new float [2048];
    //This can be modified to eliminate noise; 0 seems to be the most consistent
    private static float threshold = 0.032f;
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        song = musicSource.clip;
        //Also need the ability to choose music through menu (currently just has one song)
        SongDuration = song.length;
        collisionSource = sources[1];
        collision = collisionSource.clip;
        BeginMusic();
    }   

    //spectrum should be used by the obstacle manager to generate obstacle positions. 
    public void AnalyzeSong(AudioSource song) 
    {
    /*
    If I have time, do for multiple frequency sets, or expand so it only samples every few updates (maybe set to 15/sec?)
    Also, play song 1/2 sec ahead of itself so sampling works correctly here
    */        
        //This sampling is chosen to best isolate each band out of the spectrum
        musicSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris); 

        //This is the width of each band (in Hz) in the spectrum taken above
        float frequencyGranularity = (float)AudioSettings.outputSampleRate /2f /spectrum.Length;         

        for (int i = 1; i < spectrum.Length - 1; i++)
        { 
            //Square each, to eliminate some less prevalent frequencies (we only want to focus on the primary frequency in each)
            // spectrum[i] = spectrum[i] *spectrum[i];
        }
            //Compare only in the bass - midrange
        for(int j = (int)System.Math.Floor(50/frequencyGranularity); j < (int)System.Math.Ceiling(500/frequencyGranularity); j++){
            if(prevspectrum[j] - spectrum[j] > threshold && prevspectrum[j] -prevprevspectrum[j] > threshold){
                //SEND SIGNAL TO OBSTACLES
                Debug.Log("OBSTACLE");

                break;
            }
        }
        //Copy through for next run
        prevspectrum.CopyTo(prevprevspectrum, 0);
        spectrum.CopyTo(prevspectrum, 0);
         
        return;
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
       collisionSource.Play(0);
    }
    // Update is called once per frame

    /* MOVE TO OTHER CLASS, BUILD ADAPTER BETWEEN */
    void Update()
    {
        
        AnalyzeSong(musicSource);
        TimeElapsed += Time.deltaTime;

        if(TimeElapsed >= SongDuration) //Right now, song will loop endlessly
        {
            TimeElapsed = 0;
            // BeginMusic();
            gameManager.SendMessage("WonGame", 0.5f, SendMessageOptions.RequireReceiver);
            // Having the SoundMGR send the signal to save the score to Server.
            // HUD.SendMessage("SaveHS", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }
    
}
