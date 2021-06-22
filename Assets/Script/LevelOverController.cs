using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public string level2Scene;
    private void OnTriggerEnter2D(Collider2D collison)
    {
        // if (collision.gameobject.CompareTag("Player"))
        if (collison.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished by the player");
            SceneManager.LoadScene(level2Scene);
        }
    }
}
