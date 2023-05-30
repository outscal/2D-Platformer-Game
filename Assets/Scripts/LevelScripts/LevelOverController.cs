using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Complete... Congratulations");
            LevelManager.Instance.MarkCurrentLevelComplete();
            if(LevelManager.Instance.nextSceneIndex > LevelManager.Instance.Levels.Length - 1)
            {
                SceneManager.LoadScene("GameComplete");
            }
            else
            {
                SceneManager.LoadScene("LevelComplete");
            }
        }
    }
}
