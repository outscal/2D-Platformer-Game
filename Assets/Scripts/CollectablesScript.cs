using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    private GameManagerScript gameManagerScript;

    private void Start()
    {
        gameManagerScript = FindObjectOfType<GameManagerScript>();
        if (gameManagerScript != null)
        {
            Debug.Log("GameManager not found");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collectable Collected!");
            gameManagerScript.score += 1;
            gameManagerScript.UpdateScoreText();
            Destroy(gameObject);
        }
    }
}