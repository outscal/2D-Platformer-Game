using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource runSource;
    public static SoundManagerScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayUIButtonClip()
    {
        PlayOneShot(buttonClick);
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }

    public void PlayRunSound()
    {
        if (!runSource.isPlaying)
            runSource.Play();
    }

    public void StopRunSound()
    {
        runSource.Pause();
    }
}
