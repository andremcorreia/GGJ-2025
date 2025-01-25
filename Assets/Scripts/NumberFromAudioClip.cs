using UnityEngine;

public class NumberFromAudioClip : MonoBehaviour
{
    public float sensibility = 10f;
    public float threshold = 0.1f;
    
    private AudioLoudnessDetector _audioLoudnessDetector;
    
    [HideInInspector] public float loudness;
    
    // Start is called before the first frame update
    private void Start()
    {
        _audioLoudnessDetector = GetComponent<AudioLoudnessDetector>();

        if (!Mathf.Approximately(sensibility, GameManager.Instance.microphoneSensitivity))
            sensibility = GameManager.Instance.microphoneSensitivity;
    }

    // Update is called once per frame
    private void Update()
    {
        loudness = _audioLoudnessDetector.GetLoudnessFromMicrophone();
        
        loudness *= sensibility;
        
        if (loudness < threshold) loudness = 0f;
        if (loudness > 1) loudness = 1f;
    }
}
