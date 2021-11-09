using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _gameOverText;
    private LeveloverController _levelOver;

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
}
