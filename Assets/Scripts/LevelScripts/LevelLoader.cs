using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string Level;

    
    public void load()
    {

        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(Level);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this game unless you unlock it");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(Level);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(Level);
                break;
        }
    }
}
