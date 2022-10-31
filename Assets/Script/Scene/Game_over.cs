using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_over : MonoBehaviour
{
   public void Main_menu()
    {
        SceneManager.LoadScene("Start_menu");
    }

    public void Try_again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
