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
    public SoundType[] SoundsList;

    private void Awake()
    {
        if(instance == null)
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
        PlayMusic(Sounds.Music);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("clip not found ");
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if(clip !=null)
        {
            if(!soundEffect.isPlaying)
                soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("clip not found ");
            
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(SoundsList, i => i.soundType == sound);
        if(item!=null)
        {
            return item.soundClip;
        }
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
    Music,
    PlayerMovement,
    PlayerDeath,
    PlayerJump,
    PlayerHurt,
    ChomperMovement,
    GunnerMovement,
    EnemyDeath
    
}
