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
        musicSource = GetComponent<AudioSource>();
        song = musicSource.clip;
        //Add in other audio sources here
        //Also need the ability to choose music through menu (currently just has one song)
        SongDuration = song.length;
    }

    public float[] AnalyzeSong(AudioSource song)
    {
        float[] samples = song.GetOutputData(1024, 1);
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
