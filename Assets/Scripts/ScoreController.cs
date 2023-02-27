using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI ScoreUI;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScoreUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
        
    }
    void Refresh()
    {
        ScoreUI.text = "Score: " + score;
    }
    public void Scoreup(int increment)
    {
        score += increment;
    }
}
