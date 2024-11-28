using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonController : MonoBehaviour
{
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
