using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    private AudioSource musicSource;
    private AudioClip song;
    public float TimeElapsed = 0;
    public float SongDuration;
    private AudioClip collision;
    public AudioSource collisionSource;
    public float[] samples = new float[2048];
    void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        song = musicSource.clip;
        //Also need the ability to choose music through menu (currently just has one song)
        SongDuration = song.length;
        collisionSource = sources[1];
        collision = collisionSource.clip;
        AnalyzeSong(musicSource);
    }

    public void AnalyzeSong(AudioSource song)
    {
        song.GetOutputData(samples, 0);
        
        //THIS IS TEMPORARY CODE, WILL BE REPLACED LATER
        float[] spectrum = new float[256];
        musicSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++)
        { 
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        } //************//
                              //more analysis done here
        return;
    }
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

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SoundOnCollision(){
       collisionSource.Play(0);
    }
    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;

        if(TimeElapsed >= SongDuration) //Right now, song will loop endlessly
        {
            TimeElapsed = 0;
            BeginMusic();
        }
    }
}
