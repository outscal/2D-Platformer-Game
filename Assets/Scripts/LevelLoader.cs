using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{

    private Button button;

    public string LevelName; 
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick); 

    }


    void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName); 
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.Play(SoundList.ButtonClickError); 
                Debug.Log("Cant play the level till you unclock it ");
                break;
            case LevelStatus.UnLocked:
                SoundManager.Instance.Play(SoundList.ButtonClick);
                Debug.Log("Can Play");
                SceneManager.LoadScene(LevelName); 
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName); 
                break;
        }      
        
    }
}
