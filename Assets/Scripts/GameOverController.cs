using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;

    void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
    }

    public void PlayeDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(1);
    }
}
