using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public static LevelManager Instance { get { return instance; } }
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
        setLevelStatus("Level1", LevelStatus.Unlocked); 
    }
    public  LevelStatus getLevelStatus(string level)
    {
        return (LevelStatus)PlayerPrefs.GetInt(level, 0);
    }
    public void setLevelStatus(string level, LevelStatus _status)
    {
        PlayerPrefs.SetInt(level, (int)_status);
    }
}
