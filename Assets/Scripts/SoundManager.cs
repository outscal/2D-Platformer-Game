using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public SoundType[] Sounds;
    public AudioSource soundEffect;
    public AudioSource Music;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        PlayMusic(global::Sounds.Music);
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = GetClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("SoundEffect not found: " + sound);
        }
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetClip(sound);
        if (clip != null)
        {
            Music.clip = clip;
            Music.Play();
        }
        else
        {
            Debug.Log("SoundEffect not found: " + sound);
        }
    }

    private AudioClip GetClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if(item != null)
        {
            return item.clip;
        }
        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip clip;
}

public enum Sounds
{
    buttonClick,
    playerDeath,
    playerMove,
    Music

}
