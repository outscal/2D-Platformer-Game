using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    #region Singleton
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(" SoundManager  Instance is NULL");
            }
            return _instance;
        }
    }
    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public AudioSource soundEffect;
    public AudioSource BGMusic;
    public SoundType[] Sounds;
    private Dictionary<SoundList, float> soundTimerdictionary;
   

    // Start is called before the first frame update
    void Start()
    {
        SMInitialize();
    }
    public void SMInitialize()
    {
        soundTimerdictionary = new Dictionary<SoundList, float>();
        soundTimerdictionary[SoundList.PlayerMove] = 0.2f;

    }

    public void Play(SoundList sound)
    {
        AudioClip clip = getSoundClip(sound); 
        if( (clip != null) && CanPlaySound(sound))
        {
            soundEffect.PlayOneShot(clip); 
        } else if ( clip == null)
        {
            Debug.Log("Sound Effect clip not found"); 
        }
    }

    public bool CanPlaySound(SoundList name)
    {
        switch (name)
        {
            case SoundList.PlayerMove:

                if (soundTimerdictionary.ContainsKey(name))
                {
                    float lastTimePlayed = soundTimerdictionary[name];
                    float timeGap = 0.1f;
                    if (lastTimePlayed + timeGap < Time.time)
                    {
                        soundTimerdictionary[name] = Time.time;
                        Debug.Log("Player sound played"); 
                        return true;
                    }
                    else return false;
                }
                else return true;
            default:
                return true;
        }
    }
    private AudioClip getSoundClip(SoundList sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        return item?.soundClip;
        
    }
}

[Serializable]
public class SoundType
{
    public SoundList soundType;
    public AudioClip soundClip; 
}


public enum SoundList
{

    ButtonClick, 
    ButtonClickError, 
    ButtonClickPlay, 
    PlayerJump, 
    PlayerDeath,
    EnemyDeath,
    PlayerMove,
    ItemCollect,
}
