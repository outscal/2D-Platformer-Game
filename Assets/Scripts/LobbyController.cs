using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public void Start()
    {
        ResetPlayerData();
        
    }
    public void ResetPlayerData()
    {
        PlayerPrefs.DeleteKey("PlayerScore");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.Save();
    }
    // This method will be called when the Play button is clicked
    public void PlayGame()
    {

        SoundController.Instance.Play(Sounds.ButtonClick);
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
