using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Services.Analytics;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }
    public SoundType[] Sounds;

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public bool IsMute = false;
    public float Volume = 1f;
    private void Awake()
    {
        if (instance == null) {
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
        IsMute = status;
    }

    public void SetVolume(float volume)
    {
        Volume = volume;
        soundEffect.volume = volume;
        soundMusic.volume = volume;
    }

    public void PlayMusic(Sounds sound)
    {
        if (IsMute) { return; }

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("clip not found");
        }
    }

   
    public void Play(Sounds sound)
    {

        if (IsMute) { return; }
        AudioClip clip = getSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("clip not found");
        }
    }



    private AudioClip getSoundClip(Sounds sound)
    {
       SoundType item =  Array.Find(Sounds, i => i.soundType == sound);
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
    BombBlast,
    KeyCollect
}
