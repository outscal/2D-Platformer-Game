using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    int score;
    void Start()
    {
        tmp= gameObject.GetComponent<TextMeshProUGUI>();
        RenderUI();
    }
    public void IncrementScore()
    {
        score+=10;
        RenderUI();
    }
    private void RenderUI(){
        tmp.text= "Score : "+ score;
    }
}
