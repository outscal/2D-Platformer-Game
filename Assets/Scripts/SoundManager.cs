using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource audioSource;        // Main audio source for playing sound
    public AudioClip startSound;           // Audio clip for Start
    public AudioClip exitSound;            // Audio clip for Exit
    public AudioClip levelSound;           // Audio clip for Level selection
    public AudioClip backSound;            // Audio clip for Back button

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Method to play a sound based on clip
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Specific methods to play each sound
    public void PlayStartSound()
    {
        PlaySound(startSound);
    }

    public void PlayExitSound()
    {
        PlaySound(exitSound);
    }

    public void PlayLevelSound()
    {
        PlaySound(levelSound);
    }

    public void PlayBackSound()
    {
        PlaySound(backSound);
    }
}
