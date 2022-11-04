using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{ private int CurrentBuildIndex;
   public void menu()
    {
        CurrentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", CurrentBuildIndex);
        SceneManager.LoadScene(1);
    }

    public void Try_again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
