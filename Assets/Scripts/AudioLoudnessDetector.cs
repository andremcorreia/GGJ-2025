using System;
using System.Linq;
using UnityEngine;

public class AudioLoudnessDetector : MonoBehaviour
{

    public int sampleWindow = 10000;

    private AudioClip _microphoneClip;

    private void Start()
    {
        MicrophoneToAudioClip();
    }

    private void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        _microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), _microphoneClip);
    }
    
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        
        if (startPosition < 0) startPosition = 0;
        
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);
        
        //compute loudness
        float totalLoudness = waveData.Sum(Mathf.Abs);

        return totalLoudness / sampleWindow;
    }
}
