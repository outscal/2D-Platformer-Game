using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance{get{return instance;}}
    public AudioSource sfx;
    public AudioSource soundMusic;
    public bool isMute = false;
    public float Volume;
    public float effectVolume;
    public SoundType[] allSound;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SetVolume(Volume,effectVolume);
        PlayMusic(Sounds.Music);
    }
    public void Mute (bool Status)
    {
        isMute = Status;
    }
    public void PlayMusic(Sounds sounds)
    {
        if(isMute)
        {
            return;
        }
        AudioClip clip = getSoundClip(sounds);
        if(clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
    }
    public void SetVolume(float mVolume,float effectVol)
    {
        soundMusic.volume = mVolume;
        sfx.volume = effectVol;
    }
    public void Play(Sounds sounds)
    {
        if(isMute)
        {
            return;
        }
        AudioClip clip = getSoundClip(sounds);
        if(clip != null)
        {
            sfx.PlayOneShot(clip);
        }
        else{
            Debug.LogError("Clip not found for sound type: " + sounds);
        }
    }
   private AudioClip getSoundClip(Sounds sound)
   {
    SoundType item = Array.Find(allSound, i => i.soundType == sound);
    if(item != null )
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
    PlayerDeath,
    KeyPick,
    Teleporter,
    PlayerAttack,
    EnemyDeath,
    Afterdeath,
    StartBtn,
    PlayerHurt,
    EnemyAttack,
    footStep,
    jumpsound,
}
