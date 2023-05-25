using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_to_play : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void exit_game()
    {
        Application.Quit();
    }
}
