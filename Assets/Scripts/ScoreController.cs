using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void ScoreIncrease(int increament)
    {

        score += increament;
        RefreshUI();
    }

    public void RefreshUI()
    {

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
