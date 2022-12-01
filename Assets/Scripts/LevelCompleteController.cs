//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() !=null)
        {
            Debug.Log("Level Complete");
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
        else
        {
            Debug.Log("Level Not Complete");
        }
    }
}
