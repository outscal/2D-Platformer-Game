using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUiScore();
    }

    public void UpdateScore(int _scoreToAdd)
    {
        score += _scoreToAdd;
    }

    void UpdateUiScore()
    {
        _scoreText.text = "Score :" + score;
    }
}
