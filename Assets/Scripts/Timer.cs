using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    [HideInInspector] public float elapsedTime = 0f;
    public string score;
    private bool dead = false;

    public void Stop()
    {
        dead = true;
    }

    void Update()
    {
        if (dead)
        {
            Destroy(gameObject);
        }
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        score = $"{minutes:D2}:{seconds:D2}";
        timerText.text = score;
    }
}
