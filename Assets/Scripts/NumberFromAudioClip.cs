using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NumberFromAudioClip : MonoBehaviour
{
    public float loudnessScaleSensibility = 5f;
    public float loudnessSpeedSensibility = 5f;
    public float threshold = 0.1f;
    
    private AudioLoudnessDetector _audioLoudnessDetector;
    
    [HideInInspector] public float scaleLoudness;
    [HideInInspector] public float speedLoudness;
    
    // Start is called before the first frame update
    private void Start()
    {
        _audioLoudnessDetector = GetComponent<AudioLoudnessDetector>();
    }

    // Update is called once per frame
    private void Update()
    {
        float loudness = _audioLoudnessDetector.GetLoudnessFromMicrophone();
        
        scaleLoudness = loudness * loudnessScaleSensibility;
        speedLoudness = loudness * loudnessSpeedSensibility;
        
        if (scaleLoudness < threshold) scaleLoudness = 0f;
        if (speedLoudness < threshold) speedLoudness = 0f;
    }
}
