using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    
    private static SoundManager instance;
    public static SoundManager Instance {get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;
   
    public SoundType[] soundArray;
    private void Awake()
    {
        CreateInstance();

        PlayMusic(Sounds.BgMusic);
        


    }
    private void Update()
    {
        soundEffect.volume= 0.2f; // seting the Value of BgMusic Low  Not Working
    }
    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void PlayMusic(Sounds sounds)
    {
        AudioClip clip = GetSoundClip(sounds);
        if (clip != null)
        {
            
            Debug.Log("Sound ==" + sounds + "Clip Name ==" + clip);
            if (sounds == Sounds.BgMusic)
            {
               
                soundMusic.clip = clip;
                soundMusic.Play();
            }
        }
        else
        {
            Debug.Log("Sound i not found ==" + sounds);
        }
    }

    public void PlaySounds(Sounds sounds)
    {
        AudioClip clip = GetSoundClip(sounds);
        if (clip != null)
        {
           soundEffect.PlayOneShot(clip);
            Debug.Log("Sound ==" + sounds+"Clip Name =="+ clip);
            if(sounds== Sounds.BgMusic)
            {

            }
        }
        else
        {
            Debug.Log("Sound i not found ==" + sounds);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
       SoundType typeItem = Array.Find(soundArray, item => item.soundType == sound);
        if(typeItem != null)
        {
            return typeItem.soundClip; // Why returning sound clip(typeItem.soundClip) if we are Searching through Sounds Array of SoundTypeClass ?
        }
        else
        {
            return null;
        }
    }
}


[Serializable]  //  what is the use of [Serializable] ?  Why we  need this?  and why using [Serializable] the SoundType array Showing Both Elements
                //  SoundType & soundClip in the inspector panel But without using [Serializable]  it's not Showing them in the inspector Panel?
                //  Why it is only Applicable for Class , Struct ,Enum only ?
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}
public enum Sounds
{

    ButtonClick,
    BgMusic,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    LevelCleared,
       Jump


}