using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LeaderboardManager : MonoBehaviour
    {

        [Header("Buttons")] 
        public Button replayButton;
        public Button creditsButton;
        
        [Header("Leaderboard")]
        public Color normalColor = Color.white;
        public Color playerColor = Color.yellow;
        public List<TextMeshProUGUI> leaderboardBrackets;

        private AudioManager _audioManager;
        private void Start()
        {
            replayButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1));
            creditsButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

            _audioManager = GetComponent<AudioManager>();
            _audioManager.Play("Leaderboard");
            
            int index = -1;
            
            for (int i = 0; i < GameManager.Instance.topScores.Count; i++)
            {
                if (!(GameManager.Instance.lastScore < GameManager.Instance.topScores[i])) continue;
                index = i;
                break;
            }

            if (index != -1)
            {
                GameManager.Instance.topScores.Insert(index, GameManager.Instance.lastScore);
                GameManager.Instance.topScores.RemoveAt(GameManager.Instance.topScores.Count - 1);
            }
            
            for (int i = 0; i < leaderboardBrackets.Count; i++)
            {
                int minutes = Mathf.FloorToInt(GameManager.Instance.topScores[i] / 60);
                int seconds = Mathf.FloorToInt(GameManager.Instance.topScores[i] % 60);

                string score = $"{minutes:D2}:{seconds:D2}";
                
                leaderboardBrackets[i].text = (i + 1) + " - " + score;
                leaderboardBrackets[i].color = (i==index) ? playerColor : normalColor;
            }
        }

    }
}
