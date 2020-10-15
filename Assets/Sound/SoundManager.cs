using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
private static SoundManager instance;
public static SoundManager Instance{get {return instance;}}
public SoundType[] Sounds;
public AudioSource audioSource;
public AudioSource audioMusic;
private void Awake(){
    if(instance==null){
        instance=this;
        DontDestroyOnLoad(gameObject);
    }
    else 
    Destroy(gameObject);
}
private void Start(){
    PlayBG(global::Sounds.music);
}
public void PlayBG(Sounds sound){
    AudioClip clip=getSoundClip(sound);
    if(clip!=null){
        audioMusic.clip=clip;
        audioMusic.Play();
    }
}
public void PlaySound(Sounds sound){
    AudioClip clip=getSoundClip(sound);
    if(clip!=null){
        audioSource.PlayOneShot(clip);
    }
}
private AudioClip getSoundClip(Sounds sound){
   SoundType item= Array.Find(Sounds, i =>i.soundType==sound);
   if(item!=null){
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
public enum Sounds{
  buttonClick,
  playerMove,
  music,
  playerDeath,
  enemyDeath
}