using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public string newScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(newScene);
        }
    }
}
