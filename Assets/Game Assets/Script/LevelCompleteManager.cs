using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteManager : MonoBehaviour {

    private void Awake() {
        if (SceneTransitionManager.GetInstance().nextLevelToLoad > 5) {
            transform.Find("NextLevelButton").GetComponent<Button>().interactable = false;
        }
    }

    public void OnNextLevelButtonClick() {
        SceneManager.LoadScene(SceneTransitionManager.GetInstance().nextLevelToLoad);
    }

    public void OnQuitButtonClick() {
        SceneManager.LoadScene(0);
    }
}
