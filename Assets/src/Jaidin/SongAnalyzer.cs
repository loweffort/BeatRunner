using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class SongAnalyzer : MonoBehaviour{
    private float[] spectrum = new float[2048];
    private float[] prevspectrum = new float[2048];
    private float[] prevprevspectrum = new float [2048];
    //This can be modified to eliminate noise; 0.002f seems to be the most consistent
    private static float threshold = 0.002f;

    //Dynamic method
    public virtual void Reset() //Resets values
    {
        float TimeElapsed = 0f;
        System.Array.Clear(prevspectrum, 0, 2048);
        System.Array.Clear(prevprevspectrum, 0, 2048);
    }

    public void DebugMethod() //Static method
    {
        Debug.Log("This is static on SongAnalyzer");
    }

//Run during Update, will detect spikes in bass range intensity, and then will signal the obstacle manager to create an obstacle
    //Takes in an AudioSource, and changes the private variables spectrum, prevspectrum, and prevprevspectrum during runtime
    public void AnalyzeSong(UnityEngine.AudioSource musicSource) 
    {
        //This sampling is chosen to best isolate each band out of the spectrum
        //Sample in mono channel to require less sampling

        musicSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris); 

        //This is the width of each band (in Hz) in the spectrum taken above
        //Divided by 2f as the sampling range of the FFT is half that of the total spectrum range
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
                // gameManager.SendMessage("GenerateObstacle", 0.5f, SendMessageOptions.RequireReceiver);
                Debug.Log("OBSTACLE");
                break;
            }
        }
        //Copy through for next run
        prevspectrum.CopyTo(prevprevspectrum, 0);
        spectrum.CopyTo(prevspectrum, 0);
         
        return;
    }
}