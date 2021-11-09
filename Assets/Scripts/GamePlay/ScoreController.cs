using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelIndicatorText;

    private LevelLoader levelLoader;
    private LevelManager levelManager; 

    private int score = 0; 

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        levelIndicatorText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshUI();     
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI(); 
    }

    private void RefreshUI()
    {
        scoreText.text = "Keys: " + score;
        //levelIndicatorText.text = levelManager.Levels[SceneManager.GetActiveScene().buildIndex]; 
    }
}
