using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//when a player falls off the platform
public class DeathController : MonoBehaviour
{
    private LivesController livesController; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player died"); 
        }
    }

    public void PlayerDied()
    {
        livesController.LoseLife(); 

        Invoke("ReloadScene", 2f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
