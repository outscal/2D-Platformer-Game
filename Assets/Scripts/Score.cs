using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int score;
    public Image[] _livesImage;
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

    public void UpdateLivesUi(int _lives)
    {
        for(int i =0; i <= _lives; i++)
        {
            if(i == _lives)
            {
                _livesImage[i].enabled = false;
            }
        }
    }
}