using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    public void OnStartButtonClick() {
        SceneManager.LoadScene(SceneTransitionManager.levelToReload);
    }

    public void OnLvlSelButtonClick() {
        SceneManager.LoadScene(4);
    }

    public void OnQuitButtonClick() {
        Application.Quit();
    }
}
