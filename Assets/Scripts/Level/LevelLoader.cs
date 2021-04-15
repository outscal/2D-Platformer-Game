using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
    {
    private Button button;
    
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level unless you unlock it");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
