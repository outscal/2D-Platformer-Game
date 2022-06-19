using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }
    public SoundType[] ListOfSounds;
    public AudioSource MusicFX;
    public AudioSource SoundFX;
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
        if(clip!=null)
        {
            SoundFX.PlayOneShot(clip);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        Debug.Log("Finding Sound");
        return Array.Find(ListOfSounds, item => item.name == sound).clipName;
    }
}
public enum Sounds
{
    ButtonClickUnlocked,
    ButtonClickLocked
}
[Serializable]
public class SoundType
{
    public Sounds name;
    public AudioClip clipName;
};