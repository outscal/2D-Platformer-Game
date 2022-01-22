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

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
           // Input.GetKeyDown(KeyCode.RightArrow);
            //soundEffect.Play();
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("clip not found for sound type:" + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
       SoundType item = Array.Find(Sounds, i => i.soundType == sound);
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
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}
