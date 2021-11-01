using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteUI; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("Level finished");

            levelCompleteUI.SetActive(true); 
        }
    }
}
