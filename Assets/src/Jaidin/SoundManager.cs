using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    private AudioSource musicSource;
    private AudioClip song;
    public float TimeElapsed = 0;
    public float SongDuration;
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        song = musicSource.clip;
        //Add in other audio sources here
        //Also need the ability to choose music through menu (currently just has one song)
        SongDuration = song.length;
        //collisionSource = sources[1];
    }

    public float[] AnalyzeSong(AudioSource song)
    {
        float[] samples = song.GetOutputData(numSamples: 1024, channel: 1);
                              //more analysis done here
        return samples;
    }
    public void PauseMusic()
    {
        musicSource.Pause();
        //pause time here
    }
    public void UnPauseMusic()
    {
        musicSource.UnPause();
        //unpause time in here also
    }
    public void BeginMusic()
    {
        musicSource.Play(0);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SoundOnCollision(){
       // collisionSource.Play(0);
    }
    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        //Add in time display here later
        if(TimeElapsed >= SongDuration) //Right now, song will loop endlessly
        {
            TimeElapsed = 0;
            BeginMusic();
        }
    }
}
