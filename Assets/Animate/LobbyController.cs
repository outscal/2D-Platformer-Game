using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    // This method will be called when the Play button is clicked
    public void PlayGame()
    {
        // Load Scene 1 (index 1 in the Build Settings)
        SceneManager.LoadScene(1);
    }

    // This method will be called when the Quit button is clicked
    public void QuitGame()
    {
        // Load Scene 3 (index 3 in the Build Settings)
        SceneManager.LoadScene(3);
    }
}
