using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    
    
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
                Destroy(other.gameObject);

                Debug.Log("Player Has Won The Game");

                SceneManager.LoadScene("GameOverScreen");
            }
            
        }
    }
}
