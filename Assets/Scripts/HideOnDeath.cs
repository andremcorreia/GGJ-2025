using System;
using Audio;
using UnityEngine;

public class HideOnDeath : MonoBehaviour
{
    public GameObject menu;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GetComponentInParent<AudioManager>();
    }

    public void HideOnDeathFunction()
    {
        _audioManager.Play("Lose");
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
