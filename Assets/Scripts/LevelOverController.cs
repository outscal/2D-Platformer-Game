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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.GetComponent<PlayerController>();
        levelCompletePanel.SetActive(true);
        Debug.Log("Level Complete");

        btnNextLevel.onClick.AddListener(ButtonClick);

        void ButtonClick()
        {
            SceneManager.LoadScene(sceneName);

        }
    }
}
