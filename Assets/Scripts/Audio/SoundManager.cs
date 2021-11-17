using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public bool IsMute = false;
    public float Volume = 1f;
    public static SoundManager Instance {get{return instance;}}
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public SoundType[] Sounds;
    public void Mute(bool status)
    {
        IsMute = status;
    }
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetVolume(float volume)
    {
        Volume = volume;
        soundEffect.volume = Volume;
        soundMusic.volume = Volume;
    }
    public void Play(Sounds sound)
    {
        if(IsMute)
        return;
        AudioClip clip = getSoundClip(sound);
        if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Clip not processed for: " + sound);
        }
    }
    private void Start()
    {
        SetVolume(0.5f);
        PlayMusic(global::Sounds.Music);
    }
    public void PlayMusic(Sounds sound)
    {
        if(IsMute)
        return;
        AudioClip clip = getSoundClip(sound);
        if(clip!=null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("Clip not processed for: " + sound);
        }
    }
    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item =  Array.Find(Sounds, i => i.soundType == sound);
        if(item!= null)
        return item.soundClip;
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
    Music,
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}
