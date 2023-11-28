using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    public Button MenuButton;
    private void Awake()
    {
        RestartButton.onClick.AddListener(restartLevel);
        MenuButton.onClick.AddListener(Menu);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Level Restarted");
        HealthManager.Health = 3;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
