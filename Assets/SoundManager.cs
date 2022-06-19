using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }
    
    public AudioSource MusicFX;
    public AudioSource SoundFX;
    public SoundType[] ListOfSounds;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
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
        if(clip!=null && sound!=Sounds.BackgroundMusic)
        {
            SoundFX.PlayOneShot(clip);
            Debug.Log(clip.name);
        }
        if(clip != null && sound == Sounds.BackgroundMusic)
        {
            MusicFX.Play();
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        return Array.Find(ListOfSounds, item => item.name == sound).clipName;
    }
}
public enum Sounds
{
    ButtonClickUnlocked, //done
    ButtonClickLocked, // done
    BackgroundMusic, // done
    EnemyAttack, // done
    Jump, // done
    LevelFail, // done
    ItemPickup
}
[Serializable]
public class SoundType
{
    public Sounds name;
    public AudioClip clipName;
};