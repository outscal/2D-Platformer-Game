using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public string newScene;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
      if(collision.gameObject.GetComponent<PlayerControllerScript>() != null)
      {
        //level completion 
        Debug.Log("you reached the end of the level");
        SceneManager.LoadScene(newScene);
      }  
    }
}