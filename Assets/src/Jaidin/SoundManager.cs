using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public GameManager gameManager;
    public static SoundManager instance = null;
    private AudioSource musicSource;
    private AudioClip song;
    private float TimeElapsed = 0;
    public float SongDuration;
    private AudioClip collision;
    //Requires to be public to be able to tell if it is playing outside of component
    public AudioSource collisionSource;
    private float[] spectrum = new float[2048];
    private float[] prevspectrum = new float[2048];
    private float[] prevprevspectrum = new float [2048];
    //This can be modified to eliminate noise; 0.002f seems to be the most consistent
    private static float threshold = 0.002f;
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
    }   

    //Run during Update, will detect spikes in bass range intensity, and then will signal the obstacle manager to create an obstacle
    public void AnalyzeSong(AudioSource song) 
    {
        //This sampling is chosen to best isolate each band out of the spectrum
        //Sample in mono channel to require less sampling
        musicSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris); 

        //This is the width of each band (in Hz) in the spectrum taken above
        float frequencyGranularity = (float)AudioSettings.outputSampleRate /2f /spectrum.Length;         

        for (int i = 1; i < spectrum.Length - 1; i++)
        { 
            //Square each, to eliminate some less prevalent frequencies (this helps clear up some noise)
            spectrum[i] = spectrum[i] *spectrum[i];
        }
            //Compare only in the bass - midrange
        for(int j = (int)System.Math.Floor(50/frequencyGranularity); j < (int)System.Math.Ceiling(500/frequencyGranularity); j++){
            if(prevspectrum[j] - spectrum[j] > threshold && prevspectrum[j] -prevprevspectrum[j] > threshold){
                //Send signal to obstacles
                gameManager.SendMessage("GenerateObstacle", 0.5f, SendMessageOptions.RequireReceiver);
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
       collisionSource.PlayOneShot(collision);
    }
    // Update is called once per frame

    /* MOVE TO OTHER CLASS, BUILD ADAPTER BETWEEN */
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
