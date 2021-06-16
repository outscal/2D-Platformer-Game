using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour
{
    public string deathScene;
    private void OnTriggerEnter2D(Collider2D collison)
    {
        // if (collision.gameobject.CompareTag("Player"))
        if (collison.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player is Dead.. ");
            SceneManager.LoadScene(deathScene);
        }
    }


}
