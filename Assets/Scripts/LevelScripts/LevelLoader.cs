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
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.getLevelStatus(levelName);
        if (LevelStatus.Unlocked == levelStatus || LevelStatus.Completed == levelStatus)
        {
            SoundManager.Instance.Play(Sounds.ButtonClickUnlocked);
            SceneManager.LoadScene(levelName);

        }
        else
        {
            SoundManager.Instance.Play(Sounds.ButtonClickLocked);
            Debug.Log("Level is locked!");
        }
            

    }
}
