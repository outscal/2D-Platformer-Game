using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteDetector : MonoBehaviour
{
    [SerializeField] private LevelCompleteController levelCompleteController; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level finished");

            levelCompleteController.LevelCompleted(); 
        }
    }
}
