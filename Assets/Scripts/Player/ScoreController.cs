using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    [SerializeField]private TextMeshProUGUI keyText;

    int score;
    int key;
    public int KeyToCompleteLevel;

    
  private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }
    private void Update()
    {
        RefreshUI();
    }
public void IncreaseScore(int scoreIncrement)
{
    score = score + scoreIncrement;
    RefreshUI();
}
private void RefreshUI()
{
    scoreText.text = "Score: " + score;
    keyText.text = key + "/" + KeyToCompleteLevel;
}
public void IncreamentKey(int Keyval)
{
    key += Keyval;
    if(key >= KeyToCompleteLevel)
    {
        keyText.color = Color.green;
    }
    RefreshUI();

}
public int WhatIskey()
{
    return key;
}

   
}
