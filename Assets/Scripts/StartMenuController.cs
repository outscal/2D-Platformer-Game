using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void Setup()
    {
    gameObject.SetActive(true);
    }
    public void PlayButton()
    
    {
        Destroy (GameObject.Find ("StartMenu"));
    }

    public void ExitButton() 
    {
        Application.Quit();
        Debug.Log("Game is exiting");
 
 }
}
