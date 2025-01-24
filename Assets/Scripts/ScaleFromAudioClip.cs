using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;

    private AudioLoudnessDetector _audioLoudnessDetector;

    public float loudnessSensibility = 100f;
    public float threshold = 0.1f;
    
    // Start is called before the first frame update
    private void Start()
    {
        _audioLoudnessDetector = GetComponent<AudioLoudnessDetector>();
    }

    // Update is called once per frame
    private void Update()
    {
        float loudness = _audioLoudnessDetector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold) loudness = 0;
        
        //lerp value from min scale to max scale
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
