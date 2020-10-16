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
        
    }
    public void SMInitialize()
    {
        soundTimerdictionary = new Dictionary<SoundList, float>();
        soundTimerdictionary[SoundList.PlayerMove] = 0.5f;

    }

    public void Play(SoundList sound)
    {
        AudioClip clip = getSoundClip(sound); 
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip); 
        } else
        {
            Debug.Log("Sound Effect clip not found"); 
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
}
