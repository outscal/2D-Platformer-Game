using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeath : MonoBehaviour
{   public string NextScene;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController> () != null)
        {
            Debug.Log("YOu DIED");
            SceneManager.LoadScene(NextScene);
        }
    }
}
