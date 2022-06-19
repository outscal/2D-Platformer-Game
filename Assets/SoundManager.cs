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
    public bool isMute = false;
    public float volume = 1f;

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
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        Debug.Log(clip.name);
        if (clip!=null && sound!=Sounds.BackgroundMusic)
        {
            SoundFX.PlayOneShot(clip);
           
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
    public void Mute(bool _status)
    {
        isMute = _status;
        MusicFX.mute = _status;
    }
    public void setVolume (float _volume)
    {
        volume = _volume;
        SoundFX.volume = volume;
        MusicFX.volume = 0.25f*volume;

    }
}
public enum Sounds
{
    ButtonClickUnlocked, //done
    ButtonClickLocked, // done
    BackgroundMusic, // done
    EnemyAttack, // done
    Jump, // done
    Walk,
    LevelFail, // done
    ItemPickup // done
}
[Serializable]
public class SoundType
{
    public Sounds name;
    public AudioClip clipName;
};