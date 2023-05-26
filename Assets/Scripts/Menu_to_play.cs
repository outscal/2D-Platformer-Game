using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_to_play : MonoBehaviour
{
    public GameObject level_select;
    public GameObject to_menu;

    private void Awake()
    {
        level_select.SetActive(false);
        to_menu.SetActive(true);
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void exit_game()
    {
        Application.Quit();
    }

    public void to_level_select()
    {
        level_select.SetActive(true);
        to_menu.SetActive(false);
    }

    public void to_menu_select()
    {
        level_select.SetActive(false);
        to_menu.SetActive(true);
    }
}
