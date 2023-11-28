using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    private void Awake()
    {
        RestartButton.onClick.AddListener(restartLevel);
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
}
