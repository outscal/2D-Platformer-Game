using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour
{
    
    int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision detected");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
