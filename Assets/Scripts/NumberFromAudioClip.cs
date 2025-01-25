using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NumberFromAudioClip : MonoBehaviour
{
    public float Sensibility = 5f;
    public float threshold = 0.1f;
    
    private AudioLoudnessDetector _audioLoudnessDetector;
    
    [HideInInspector] public float loudness;
    
    // Start is called before the first frame update
    private void Start()
    {
        _audioLoudnessDetector = GetComponent<AudioLoudnessDetector>();
    }

    // Update is called once per frame
    private void Update()
    {
        loudness = _audioLoudnessDetector.GetLoudnessFromMicrophone();
        
        loudness = loudness * 10;
        
        if (loudness < threshold) loudness = 0f;
        if (loudness > 1) loudness = 1f;
    }
}
