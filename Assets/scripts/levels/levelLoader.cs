using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class levelLoader : MonoBehaviour
{
    Button btn;
    public string levelName;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelStatus levelStatus = levelManager.Instance.GetLevelStatus(levelName);

        switch(levelStatus)
        {
            case LevelStatus.locked:
                soundManager.Instance.Play(Sounds.ButtonClickLocked);
                break;
            case LevelStatus.unlocked:
                soundManager.Instance.Play(Sounds.ButtonClickNormal);
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.completed:
                SceneManager.LoadScene(levelName);
                break;
        }
        
    }
}
