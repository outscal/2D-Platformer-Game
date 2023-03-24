using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLaoder : MonoBehaviour
{
    public Button levelButton;
    public string LevelName;
    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(OnClickLoad); // why the fucntion onClickLoad passed without Parantheses inside the AdListener ?
    }
    
   
    private void OnClickLoad()
    {
        LevelStatus levelStatus = LevelManager.instance.GetLeveLStatus(LevelName);
        Debug.Log("Level status ==" + levelStatus+"--"+(int)levelStatus);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                print("Level is currently Locked ");
               

                break;
            case LevelStatus.Unclocked:
                SoundManager.Instance.PlaySounds(Sounds.ButtonClick);
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName); print("This Level is    Now unlcoked ");

                break;
            case LevelStatus.Complete:
                SoundManager.Instance.PlaySounds(Sounds.ButtonClick);
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName); 
                print("This Level is    Now Complete ");
                break;
            default:
                break;
        }
    }

   
}
