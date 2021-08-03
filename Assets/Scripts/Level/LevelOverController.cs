using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour

{

    public Button btnNextLevel;

    public GameObject levelCompletePanel;

    public string sceneName;

    private void Awake()
    {
        levelCompletePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.GetComponent<PlayerController>();
        
        levelCompletePanel.SetActive(true);
        Debug.Log("LevelOverController Says Level is Complete");
        LevelManager.Instance.MarkLevelComplete();


        btnNextLevel.onClick.AddListener(ButtonClick);

        

        
    }
    void ButtonClick()
    {
        SceneManager.LoadScene(sceneName);

    }
}
