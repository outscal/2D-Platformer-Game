using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{

    public Button[] button;

    private void Awake()
    {
        // Ensure you are using the same key name
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;

        }

        for (int i = 0; i < levelAt; i++)
        {
            button[i].interactable = true;

        }


    }
    // Method for loading Level 1 (build index 1)
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1); // Load Level 1 (build index 1)
    }

    // Method for loading Level 2 (build index 2)
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2); // Load Level 2 (build index 2)
    }
}
