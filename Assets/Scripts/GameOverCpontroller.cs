using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCpontroller : MonoBehaviour
{
    public Button restartBtn;

    private void Awake()
    {
        restartBtn.onClick.AddListener(ReloadLevel);
    }
    public void playerDead()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);

    }
}
