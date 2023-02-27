using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {

    private void Awake() {
        int lockAfterLevel = SceneTransitionManager.GetInstance().lastLevelUnlocked;

        for (int i = lockAfterLevel + 1; i <= 5; i++) {
            transform.GetChild(2).GetChild(i - 1).GetComponent<Button>().interactable = false;
        }
    }

    public void OnLevelClick(int i) {
        SceneManager.LoadScene(i);

        BGMPlayer.GetInstance().ButtonSound();
    }
}
