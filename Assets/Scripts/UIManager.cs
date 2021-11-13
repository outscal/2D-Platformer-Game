using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _scoreText;
    private LeveloverController _levelOver;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprites;

    private void Awake()
    {
        _levelOver = GameObject.Find("LevelComplete").GetComponent<LeveloverController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_levelOver == null)
        {
            Debug.LogError("The LevelOverController is null");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void gameStatus()
    {
        Debug.Log("print UI");
        _gameOverText.gameObject.SetActive(true);

    }
    public void displayScoreText(int score)
    {
        _scoreText.text = "Score :" + score;
    }
    public void updateLives(int currentLives)
    {
        //access display images sprite
        // give new one based on current Index
        _livesImage.sprite = _livesSprites[currentLives];
    }
}
