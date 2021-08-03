 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("LEVEL IS LOCKED");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}
