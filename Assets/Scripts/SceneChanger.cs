using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelQuit()
    {
        //For going to lobby screen from level
        SceneManager.LoadSceneAsync(0);
    }

    public void LevelLoad(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }
    public void Quitter()
    {
        Application.Quit();
    }

}
