using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public string[] levels;
    public static LevelManager Instance { get { return instance; } }

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


    // Start is called before the first frame update
    void Start()
    {
        if (GetLevelStatus(levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkedLevelComplete()
    {
        var currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;

        SetLevelStatus(levels[currentLevelIndex], LevelStatus.Completed);

        int nextLevel = currentLevelIndex + 1;

        if (nextLevel < levels.Length)
        {
            SetLevelStatus(levels[nextLevel], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string levelName)
    {
        return (LevelStatus)PlayerPrefs.GetInt(levelName, 0);
    }

    public void SetLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName, (int)levelStatus);

        Debug.Log("levelName - " + levelName + "," + levelStatus);
    }
}
