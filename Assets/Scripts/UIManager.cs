using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelBackToMainButton;
    [SerializeField] private Button restartBackToMainButton;
    private void Start()
    {
        nextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1));
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        nextLevelBackToMainButton.onClick.AddListener(() => SceneManager.LoadScene("Lobby"));
        restartBackToMainButton.onClick.AddListener(() => SceneManager.LoadScene("Lobby"));
    }
   
}
