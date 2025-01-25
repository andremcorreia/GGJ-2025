using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class TitleScreenManager : MonoBehaviour
    {
        [Header("Buttons")]
        public Button playButton;
        public Button optionsButton;
        public Button storyButton;
        public Button tutorialButton;
        public Button exitButton;
        public Button backButton1;
        public Button backButton2;
        public Button backButton3;
        
        [Header("Screens")]
        public GameObject titleScreen;
        public GameObject optionsScreen;
        public GameObject storyScreen;
        public GameObject tutorialScreen;

        private AudioManager _audioManager;

        private void Start()
        {
            playButton.onClick.AddListener(StartGame);
            optionsButton.onClick.AddListener(ShowOptions);
            storyButton.onClick.AddListener(ShowStory);
            tutorialButton.onClick.AddListener(ShowTutorial);
            exitButton.onClick.AddListener(ExitGame);
            backButton1.onClick.AddListener(ShowTitle);
            backButton2.onClick.AddListener(ShowTitle);
            backButton3.onClick.AddListener(ShowTitle);
            
            _audioManager = GetComponent<AudioManager>();
            _audioManager.Play("TitleScreen");
            
            if (GameManager.Instance.microphoneSensitivity < 1) GameManager.Instance.microphoneSensitivity = 10;
        }

        private static void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void ShowTitle()
        {
            optionsScreen.SetActive(false);
            storyScreen.SetActive(false);
            tutorialScreen.SetActive(false);
            titleScreen.SetActive(true);
        }
        
        private void ShowOptions()
        {
            titleScreen.SetActive(false);
            storyScreen.SetActive(false);
            tutorialScreen.SetActive(false);
            optionsScreen.SetActive(true);
        }

        private void ShowStory()
        {
            titleScreen.SetActive(false);
            optionsScreen.SetActive(false);
            tutorialScreen.SetActive(false);
            storyScreen.SetActive(true);
        }

        private void ShowTutorial()
        {
            titleScreen.SetActive(false);
            optionsScreen.SetActive(false);
            storyScreen.SetActive(false);
            tutorialScreen.SetActive(true);
        }

        private static void ExitGame()
        {
            Application.Quit();
        }
    }
}
