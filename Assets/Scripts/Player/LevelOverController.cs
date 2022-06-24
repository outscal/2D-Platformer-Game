using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{   public string NextScene;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController> () != null)
        {
            Debug.Log("Level Completed");
            SceneManager.LoadScene(NextScene);
        }
    }
}
