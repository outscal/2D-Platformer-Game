using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_collisionDetection : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collison detected with the gameover..");
        if (other.collider.CompareTag("Player"))
        {
            UI_Manager uiManager = FindObjectOfType<UI_Manager>();
            if (uiManager != null)
            {
                uiManager.HandleCollisionWithPlayer();
            }
        }
    }

}
