using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Sounds
{
    PlayerMovement,
    PlayerFailing,
    StartingLevel,
    CompleteLevel,
    PlayerDie,
    EnmeyMovement,
    BackgroundMusic,
    SoundEffect,
    GameOver

}
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance {  get { return instance; } }
    public AudioSource buttonSource;
    public AudioSource backgroundMusic;
    public AudioSource playerSound;
    public SoundType[] SoundArray;

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
        PlayBackgroundMusic(global::Sounds.BackgroundMusic);
    }

    public void PlayBackgroundMusic(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        backgroundMusic.clip = clip;
        backgroundMusic.Play();

    }

    public void ButtonSound(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        buttonSource.PlayOneShot(clip);
    }

    public void PlayerSound(Sounds sound)
    {
        AudioClip clip = GetAudioClip(sound);
        playerSound.PlayOneShot(clip);
    }

    private AudioClip GetAudioClip(Sounds sound)
    {
       SoundType item =   Array.Find(SoundArray, i => i.type == sound);
        if (item != null)
        {
           return item.AudioClip;
        }
        return null;

    }
}
