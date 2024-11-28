using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

  

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;

    public bool isMute = false; 

    public float Volume = 1.0f; 



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
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
        soundEffect.volume = volume;    
        soundMusic.volume = volume; 
    }

    public void PlayMusic(Sounds sound)
    {

        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip; 
            soundMusic.Play();
        }
        else
        {
            Debug.Log("Clip is not there");
        }

    }

    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);  
        }
        else
        {
            Debug.Log("Clip is not there");
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
     SoundType item = Array.Find(Sounds, i => i.soundType == sound);

        if(item != null)
        {
            return item.soundClip;
        }
        else
            { return null;}    

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
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,

}