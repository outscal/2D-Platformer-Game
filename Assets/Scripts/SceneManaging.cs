using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaging : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(int sceneIndex)
    {
        Debug.Log(sceneIndex);
       // SceneManager.LoadScene(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
