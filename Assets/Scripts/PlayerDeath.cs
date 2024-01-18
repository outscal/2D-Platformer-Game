using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    public Player player;
    
    [SerializeField] private bool DamageTrigger = true;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the PlayerController script
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            if (DamageTrigger)
            {
                player.OnTakeDamage();
            }
            else
            {
                LevelManager levelManager = LevelManager.Instance;
                levelManager.SetPlayerScore(player.GetScore());

                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

                // Calculate the index of the next scene
                int nextSceneIndex = currentSceneIndex + 1;

                // Load the next scene
                SceneManager.LoadScene(nextSceneIndex);
            }
            
        }
    }
}
