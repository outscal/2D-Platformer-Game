using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
            Debug.Log("Can't play this till you unlock it");
            break;
            case LevelStatus.Unlocked:
            SoundManager.Instance.Play(Sounds.ButtonClick);
            SceneManager.LoadScene(LevelName);
            break;
            case LevelStatus.Completed:
            SceneManager.LoadScene(LevelName);
            break;
        }
    }
}