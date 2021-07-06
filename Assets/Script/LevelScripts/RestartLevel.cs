using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public string restartGame;
    public string Scene01;
    public string Scene02;


    public void onButtonClick()
    {
        SceneManager.LoadScene(restartGame); 
    }
    public void onEasyButtonClick()
    {
        Debug.Log("1");
        SceneManager.LoadScene(Scene01); 
    }
    public void onHardButtonClick()
    {
        Debug.Log("2");
        SceneManager.LoadScene(Scene02); 
    }

}
