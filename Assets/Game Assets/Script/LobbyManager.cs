using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    public void OnStartButtonClick() {
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClick() {
        Application.Quit();
    }
}
