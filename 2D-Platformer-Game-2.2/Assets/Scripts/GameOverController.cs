using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);    
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel ()
    {
    Debug.Log("Reloading Scene 0 ........");
    SceneManager.LoadScene(1);
    }
}
