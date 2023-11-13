using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<playerMovement>() != null)
        {
            Debug.Log("Level is Over: ");
            SceneManager.LoadScene(0);
            LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
        }
    }
}
