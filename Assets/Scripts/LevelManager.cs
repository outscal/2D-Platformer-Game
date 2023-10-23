using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelStat
{
    Locked, Unlocked, Completed
}

public class LevelManager : MonoBehaviour
{
    private int leveltoUnlock;
    [SerializeField] private string lv1;

    private void Start()
    {
        if(GetLevelStatus(lv1) == LevelStat.Locked)
        {
            SetLevelStatus(lv1, LevelStat.Unlocked);
        }
    }
    public LevelStat GetLevelStatus(string level)
    {
        LevelStat levelStatus = (LevelStat)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStat levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
    public void ToNextLevel()
    {
        SoundManager.Instance.SFXSounds(SoundTypes.OnClick);
        Scene currentscene = SceneManager.GetActiveScene();
        SetLevelStatus(currentscene.name, LevelStat.Completed);

        leveltoUnlock = currentscene.buildIndex + 1;
        if( leveltoUnlock < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(leveltoUnlock);
            Debug.Log("Level unlocked " + leveltoUnlock);
        }
        
    }

}
