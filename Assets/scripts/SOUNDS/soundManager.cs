using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    private static soundManager instance;
    public static soundManager Instance { get { return instance; } }
    public AudioSource SoundEffect;
    public AudioSource soundMusic;
    public AudioSource PlayerSounds;
    
    public SoundType[] sounds;
    public MusicType[] music;
    public PlayerSounds[] playerS;
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    //bg musci
    public void PlayBGMusic(Music  music)
    {
        AudioClip clip = getMusicClip (music);
        if (clip != null)
        {
            soundMusic.Stop();
            soundMusic.clip = clip;
            soundMusic.Play();
            
               
        }           
            
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.Stop();
            //if (!SoundEffect.isPlaying)
                SoundEffect.PlayOneShot(clip);
        }
           
    } public void PlayPlayerSounds( playerSounds sound)
    {
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            

            if (!PlayerSounds.isPlaying)
            {
                PlayerSounds.Stop();               
                PlayerSounds.PlayOneShot(clip);
            }
             
        }
           
    }
    // button Effects
    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        else
            return null;
    }  private AudioClip getMusicClip(Music Music)
    {
       MusicType  item = Array.Find(music, i => i.musicType == Music);
        if (item != null)
            return item.soundClip;
        else
            return null;
    }

    // player Sounds effect
    private AudioClip getSoundClip(playerSounds sound)
    {
        PlayerSounds item = Array.Find(playerS, i => i.playerSounds == sound);
        if (item != null)
            return item.soundClip;
        else
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
    ButtonClickNormal,
    ButtonClickLocked,
    healthLoose,
    healthGain,
    pickUpCoin,
    enemyAttack,
    enemyDie,
  
   

    }

[Serializable]
public class MusicType
{   
    public Music musicType;
    public AudioClip soundClip;
}
    public enum Music
    {
    lobbyBgMusic,
    gamePlayMusic,
    gameOverMusic,

    }
[Serializable]
public class PlayerSounds
{   
    public playerSounds playerSounds;
    public AudioClip soundClip;
}
    public enum playerSounds
    {
    PlayerMove,
    PlayerRun,
    Playerhurt,
    playerJump,
    playerAttack
}

