using TMPro;
using UnityEngine;

public class NumberFromAudioClip : MonoBehaviour
{
    public int sensibility = 10;
    public float threshold = 0.1f;
    
    private AudioLoudnessDetector _audioLoudnessDetector;
    
    [HideInInspector] public float loudness;
    
    public TextMeshProUGUI sliderText;
    
    // Start is called before the first frame update
    private void Start()
    {
        _audioLoudnessDetector = GetComponent<AudioLoudnessDetector>();

        if (GameManager.Instance.microphoneSensitivity < 1) GameManager.Instance.microphoneSensitivity = 10;
        
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

    public void AdjustSensibility(System.Single newSensibility)
    {
        GameManager.Instance.microphoneSensitivity = (int) newSensibility;
        sensibility = GameManager.Instance.microphoneSensitivity;
        sliderText.text = sensibility.ToString();
    }
}
