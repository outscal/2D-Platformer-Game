using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {

    public void OnLevelClick(int i) {
        SceneManager.LoadScene(i);
    }
}
