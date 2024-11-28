using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] public string LevelName;

    private void Awake()
    {
        button.onClick.AddListener(TryLoadLevel);
    }

    private void TryLoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);

        switch (levelStatus)
        {
            case LevelStatus.locked:
                Debug.Log("This Level is Locked");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}