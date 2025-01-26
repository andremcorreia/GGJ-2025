using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    public GameObject pauseScreen;
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResumeGame()
    {
        Debug.Log("Pause deactivated");
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        Debug.Log(pauseScreen.activeSelf);
        Debug.Log(Time.timeScale);
    }
}
