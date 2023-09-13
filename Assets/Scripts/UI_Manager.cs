using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver_Panel;
    [SerializeField]
    private GameObject Main_Menu;
    [SerializeField]
    private GameObject ScoreText;

    void Start()
    {
        ScoreText.SetActive(false);
        GameOver_Panel.SetActive(false);
        Main_Menu.SetActive(true);
    }

    public void Play_Button()
    {
        Main_Menu.SetActive(false);
        ScoreText.SetActive(true);       
    }

    public void HandleCollisionWithPlayer()
    {
        Debug.Log("Setting Gameover to true");
        ScoreText.SetActive(false);
        GameOver_Panel.SetActive(true);
        StartCoroutine(ResetGameCoroutine());
    }
    private IEnumerator ResetGameCoroutine()
    {
        // Waiting for a short delay before checking for the "R" key press
        yield return null;

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameOver_Panel.SetActive(false);
                var scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }

            yield return null;
        }
    }
}
