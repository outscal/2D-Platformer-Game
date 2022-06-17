using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{   

    public string levelName;
    private Button button;
    

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void Start()
    {
        LevelStatus levelStatus = LevelManager.Instance.getLevelStatus(levelName);
        if (levelStatus == LevelStatus.Locked)
        {
            button.interactable = false;
        }
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.getLevelStatus(levelName);
        if (LevelStatus.Unlocked == levelStatus || LevelStatus.Completed == levelStatus)
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.Log("Level is locked!");
        }
            

    }
}
