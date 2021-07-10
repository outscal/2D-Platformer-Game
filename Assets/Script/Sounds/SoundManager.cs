using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Elle2D
{
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

        private void Start()
        {
            PlayMusic(global::Sounds.Music);
        }

        public void PlayMusic(Sounds sound)
        {

            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
            else
            {
                Debug.LogError("Clip not found : " + sound);
            }
        }

        public void Play(Sounds sound)
        {
            AudioClip clip = getSoundClip(sound);
            if (clip != null)
            {
                soundEffect.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError("Clip not found : " + sound);
            }
        }

        private AudioClip getSoundClip(Sounds sound)
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);
            if (item != null)
            {
                return item.SoundClip;
            }
            return null;
        }
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip SoundClip;
    }

}
public enum Sounds
{
    ButtonClick,
    Playermove,
    Music,
    PlayerDeath,
    EnemyDeath,
}