using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance = null;
    public GameObject gameOverPanel;
    private void Awake()
    {
        _instance = this;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
