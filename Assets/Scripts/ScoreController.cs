using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private int score;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        RefreshUI();
    }

    public void scoreIncrease ( int increment)
    {
        score += increment;
        RefreshUI();
    
    }

    private void RefreshUI(){
        scoreText.text = "Score " + score;
    }
}
