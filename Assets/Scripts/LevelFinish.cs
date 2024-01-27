using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteScreen;
    [SerializeField] string nextLevelName;

    private void Start()
    {
        levelCompleteScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            levelCompleteScreen.SetActive(true);
            collision.GetComponent<PlayerController>().enabled = false;
            LevelManager.Instance.OnLevelCompletion(nextLevelName);

        }
    }
}
