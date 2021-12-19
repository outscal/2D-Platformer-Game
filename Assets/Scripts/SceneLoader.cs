using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Levels;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
    private Button button;

    public string Levelname;

    private void Awake() 
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(Levelname);

        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cant play this level till you unlock it!");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
                SceneManager.LoadScene(Levelname);
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
                SceneManager.LoadScene(Levelname);
                break;
        }
    }
}
