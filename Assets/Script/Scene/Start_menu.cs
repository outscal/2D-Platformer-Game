using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_menu : MonoBehaviour
{
    public void Main_menu()
    {
        SceneManager.LoadScene("Start_menu");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Start_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Select_level_button()
    {
        SceneManager.LoadScene("Level_selection");
    }

    private int ToContinueScene;


    public void ContinueButton()
    {
        
        ToContinueScene = PlayerPrefs.GetInt("SavedScene");

        if (ToContinueScene != 0)
        {
            SceneManager.LoadScene(ToContinueScene);
        }

        else { return; }
    }
}
