using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {

    private void Awake() {
        int lockAfterLevel = SceneTransitionManager.lastLevelUnlocked;

        for (int i = lockAfterLevel + 1; i <= 5; i++) {
            transform.Find("Panel/L" + i + "Button").GetComponent<Button>().interactable = false;
        }
    }

    public void OnLevelClick(int i) {
        SceneManager.LoadScene(i);
    }
}
