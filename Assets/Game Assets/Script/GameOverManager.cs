using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public void OnReplayButtonClick() {
        SceneManager.LoadScene(SceneTransitionManager.levelToReload);
    }

    public void OnQuitButtonClick() {
        SceneManager.LoadScene(0);
    }
}
