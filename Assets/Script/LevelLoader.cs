using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    Button button;

    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        AudioManager.Instance.Play(SoundType.ButtonClick);

        if (levelName == "Lobby")
        {
            SceneManager.LoadScene(levelName);
            return;
        }

        switch (LevelManager.Instance.GetLevelStatus(levelName))
        {
            case LevelStatus.Locked:
                Debug.Log(levelName + " is Locked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
            default:
                break;
        }
    }
}
