using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    private static soundManager instance;
    public static soundManager Instance { get { return instance; } }
    public AudioSource SoundEffect;
    public AudioSource soundMusic;
    public SoundType[] sounds;
    public MusicType[] music;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    public void PlayBGMusic(Music  music)
    {
        AudioClip clip = getMusicClip (music);
        if (clip != null)
            soundMusic.Play();
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
            SoundEffect.PlayOneShot(clip);
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        else
            return null;
    }  private AudioClip getMusicClip(Music Music)
    {
       MusicType  item = Array.Find(music, i => i.musicType == Music);
        if (item != null)
            return item.soundClip;
        else
            return null;
    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
   
    public AudioClip soundClip;
}

    public enum Sounds
    {
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,

    }

[Serializable]
public class MusicType
{   
    public Music musicType;
    public AudioClip soundClip;
}
    public enum Music
    {
    lobbyBgMusic,
    gamePlayMusic,
    gameOverMusic,

    }

