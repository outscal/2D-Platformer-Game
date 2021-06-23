using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public string restartGame;
    public void onButtonClick()
    {
        SceneManager.LoadScene(restartGame);
    }

}
