using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    public GameObject gameover_screen;
    [SerializeField] Button restart;
    [SerializeField] Button mainmenu;

    private void Awake()
    {
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
        gameover_screen.SetActive(false);
    }

    public void Restart()
    {
        int current_scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
