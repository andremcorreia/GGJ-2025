using Audio;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private AudioManager _audioManager;
    
    private void Start()
    {
        _audioManager = GetComponent<AudioManager>();
        _audioManager.Play("GameMusic");
    }
}
