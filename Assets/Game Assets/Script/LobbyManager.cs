using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    public void OnStartButtonClick() {
        SceneManager.LoadScene("Assets/Scenes/LevelSelectionScene.unity");

        BGMPlayer.GetInstance().ButtonSound();
    }

    public void OnQuitButtonClick() {
        Application.Quit();

        BGMPlayer.GetInstance().ButtonSound();
    }
}
