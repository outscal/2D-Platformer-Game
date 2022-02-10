using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison) {
        if(collison.gameObject.GetComponents<PlayerController>() != null){
            SceneManager.LoadScene("Start");
            Debug.Log("New Scene loaded");
        }
    }
}
