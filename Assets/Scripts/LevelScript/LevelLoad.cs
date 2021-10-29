using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoad : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake(){
        button=GetComponent<Button>();
        button.onClick.AddListener(onClick);

    }
    private void onClick(){
        if(LevelName=="Lobby"){
            SceneManager.LoadScene(LevelName);
        }
        LevelStatus levelStatus =LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus){
            case LevelStatus.Locked:
                 Debug.Log("Level is locked.");
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
