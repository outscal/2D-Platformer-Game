using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSFX, BGSound;
    private static AudioManager instance;
    public List<Sound> sounds = new List<Sound>();
    public static AudioManager Instance { get { return instance; } }
    public bool isMute;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisableSound(bool Disable)
    {
        if (Disable)
        {
            isMute = true;
            BGSound.Stop();
        }
        else
        {
            isMute = false;
            PlayMusic();
        }
    }

    private void Start()
    {
        PlayMusic();
    }
    void PlayMusic()
    {
        if (!isMute)
        {
            BGSound.Play();
        }
    }

    public void Play(SoundType soundType)
    {
        if (!isMute)
        {
            Debug.Log("soundType - " + soundType);
            audioSFX.PlayOneShot(GetSoundClip(soundType));
        }
    }

    public AudioClip GetSoundClip(SoundType Stype)
    {
        Sound sound = sounds.Find(x => x.soundType == Stype);
        return sound.soundClip;
    }

}

[System.Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip soundClip;
}

public enum SoundType
{
    ButtonClick,
    EnemyCollide,
    Collection,
    Pause,
    GameOver,
    GameComplete
}