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
    public bool IsMute = false;
    public float Volume = 1f;

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
        SetVolume(0.25f);
        PlayMusic(global::Sounds.BgMusic); 
    }

    public void Mute (bool status)
    {
        IsMute = status;
    }

    public void SetVolume (float volume)
    {
        Volume = volume;
        soundEffect.volume = volume;
        soundMusic.volume = volume;
    }


    public void PlayMusic (Sounds sound)
    {
        if (IsMute)
            return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
            soundMusic.loop = true;
        }
        else
        {
            Debug.LogError("Clip not Found for sound type: " + sound);
        }

    }

    public void Play(Sounds sound)
    {
        if (IsMute)
            return;

        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not Found for sound type: " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item =  Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
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
    ButtonClick,
    BgMusic,
    PlayerMovement,
    PlayerDeath,
    PlayerJump,
    PlayerCrouch,
    KeyCollect,
    NewLevel,
    FinishingLevel,
    Failinglevel,


}