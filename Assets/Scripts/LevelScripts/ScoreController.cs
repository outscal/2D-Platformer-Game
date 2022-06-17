using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    
    //private int score;
    private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        //score = 0;
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();

    }
    public void IncreaseScore(int increment)
    {
        GameManager.Instance.setPlayerScore(increment);
    }
    private void RefreshUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.getPlayerScore().ToString();
    }
}
