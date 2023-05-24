using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;

    private void Awake()
    {
        restartButton = GetComponentInChildren<Button>();
        gameObject.SetActive(false);
        restartButton.onClick.AddListener(ReloadLevel);
    }

    private void Start()
    {
        //restartButton.onClick.AddListener(ReloadLevel);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Game Over... Try Again");
            SceneManager.LoadScene("Level1");
        }
    }
}
