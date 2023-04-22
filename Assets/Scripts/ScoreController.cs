using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake() {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void increaseScore(int increment){
        score += increment;
        RefreshUI();
    }
    private void RefreshUI(){
        scoreText.text = "Score: " + score;
    }
}
