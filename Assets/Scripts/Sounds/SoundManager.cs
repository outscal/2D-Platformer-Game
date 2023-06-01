using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private AudioSource soundMusic;

    [SerializeField] private SoundType[] Sounds;
    [SerializeField] private float Volume = 1f;
    private bool isMute = false;
    
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
        SetVolume(0.5f);
        PlayMusic(global::Sounds.Music);
    }

    public void Mute(bool status)
    {
        isMute = status;
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume;
    }

    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        SetVolume(Volume);
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffect.clip= clip;
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;
        SetVolume(Volume);
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip= clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if(item != null)
        {
            return item.soundClip;
        }
        return null;
    }
}

[Serializable]
public class SoundType
{
    // [Serializable] makes the class visible in the inspector
    public Sounds soundType;
    public AudioClip soundClip;
    //[Range(0f, 1f)] public float volume;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    EnemyMove,
    PlayerDeath,
    EneyDeath,
    LevelComplete,
    PlayerJump,
    KeyCollect
}
