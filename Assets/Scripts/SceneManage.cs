using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    private void Update()
    {
        QuitEsc();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    void QuitEsc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
