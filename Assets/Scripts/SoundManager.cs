using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgSound;
    [SerializeField]
    private AudioSource SfxSound;   
    public AudioSource loopinSounds;
    [SerializeField]
    private AudioSource lowVolSounds;
    [SerializeField]
    private TextMeshProUGUI mute;
    [SerializeField]
    private Sounds[] sounds;
    private bool isMute = false;
    [SerializeField][Range(0f,1f)]
    private float volume = 1f;

    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    private void Awake()
    {
        if(instance == null)
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
        BGSound(SoundTypes.BGSound);
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
        mute.text = isMute ? "UnMute" : "Mute" ;
        Debug.Log(isMute);
    }

    public void SetVolume(float vol)
    {
        volume = vol;
        bgSound.volume = volume;
        SfxSound.volume = volume;
    }
    public void MovementSound(SoundTypes sound, bool play)
    {
        if (isMute)
            return;
        AudioClip clip = GetAudioClip(sound);
        if (clip != null && play)
        {
            loopinSounds.clip = clip;
            loopinSounds.Play();
        Debug.Log("PLayermoevemnt sound Loop is " + loopinSounds.loop);
        }
        else if(!play)
        {
            loopinSounds.Stop();
        }
        else
        {
            Debug.LogError("This Sound clip" + clip + " not found for the sound type " + sound);
        }
        Debug.Log("Playing sound");
    }

    public void LowVolSFXSounds(SoundTypes sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            lowVolSounds.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("This Sound clip" + clip + " not found for the sound type " + sound);
        }
    }

    public void SFXSounds(SoundTypes sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetAudioClip(sound);
        if(clip != null )
        {
            SfxSound.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("This Sound clip" + clip + " not found for the sound type " + sound);
        }      
    } 
    public void LoopingSound(SoundTypes sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetAudioClip(sound);
        if (clip != null)
        {
            loopinSounds.clip = clip;
            loopinSounds.Play();
        }
        else
        {
            Debug.LogError("This Sound clip" + clip + " not found for the sound type " + sound);
        }
    }
    public void BGSound(SoundTypes sound)
    {
        if (isMute)
            return;

        AudioClip clip = GetAudioClip(sound);
        if(clip != null)
        {
            bgSound.clip = clip;
            bgSound.Play();
        }
        else
        {
            Debug.LogError("This Sound clip" + clip + " not found for the sound type " + sound);
        }
    }

    private AudioClip GetAudioClip(SoundTypes sound)
    {
      Sounds s = Array.Find(sounds, items => items.sound == sound);
        if (s != null)
            return s.clip;
        return null;
    }
}

public enum SoundTypes
{
    BGSound,OnClick,Jump,PlayerMovement,EnemyDeath,GameOver,Collectables,Teleportation,Land,Hurt,HoveringPad
}

[Serializable]
public class Sounds
{
    public SoundTypes sound;
    public AudioClip clip;

}