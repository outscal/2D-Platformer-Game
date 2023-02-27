using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public int toScene = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SceneTransitionManager.GetInstance().UnlockTillLevel(toScene);
            SceneTransitionManager.GetInstance().nextLevelToLoad = toScene;
            SceneManager.LoadScene("Assets/Scenes/LevelCompleteScene.unity");
        }
    }
}

