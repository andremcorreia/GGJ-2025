using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class CreditsManager : MonoBehaviour
    {
        [Header("Buttons")]
        public Button titleButton;
        public Button exitButton;
        
        private AudioManager _audioManager;
        
        private void Start()
        {
            titleButton.onClick.AddListener(() => SceneManager.LoadScene(0));
            exitButton.onClick.AddListener(Application.Quit);
            
            _audioManager = GetComponent<AudioManager>();
            _audioManager.Play("CreditsMusic");
        }
    }
}
