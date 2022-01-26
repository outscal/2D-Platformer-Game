using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelOverComplete : MonoBehaviour
{
    public int NextLevel;
   
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.GetComponent<PlayerController>() != null )
       {
           Debug.Log("you completed this Level");
           LoadScene();
       }
   }
   void LoadScene()
   {
       SceneManager.LoadScene(NextLevel);
   }
}
