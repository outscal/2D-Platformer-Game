using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoadController : MonoBehaviour
{
    [SerializeField] GameObject levelButtonGameObject;
    Button[] levelButtons;
    private void Awake() {
        levelButtons = levelButtonGameObject.GetComponentsInChildren<Button>();
        foreach (Button levelButton in levelButtons) {
            levelButton.onClick.AddListener(() => { LoadLevel(levelButton.name);});
        }
    }

    void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }


}
