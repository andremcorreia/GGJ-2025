using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance { get; private set; }

    [HideInInspector] public int microphoneSensitivity;
    [HideInInspector] public int lastScore;

    [HideInInspector] public int[] topScores;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple game managers present in scene! Destroying...");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
