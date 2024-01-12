using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    private TextMeshProUGUI m_score;

    private void Awake()
    {
        m_score = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        m_score.text = "Score: " + score;
    }

    public void UpdateScore(int _score) { 
        score += _score;
        RefreshUI();
    }

}
