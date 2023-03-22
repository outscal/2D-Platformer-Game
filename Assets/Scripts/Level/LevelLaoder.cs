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
        levelButton.onClick.AddListener(OnClickLoad);
    }
    
   
    private void OnClickLoad()
    {
        LevelStatus levelStatus = LevelManager.instance.GetLeveLStatus(LevelName);
        Debug.Log("Level status ==" + levelStatus);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                print("Level is currently Unlcoked ");
               

                break;
            case LevelStatus.Unclocked:
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName); print("This Level is    Now unlcoked ");

                break;
            case LevelStatus.Complete:
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName); 
                print("This Level is    Now Complete ");
                break;
            default:
                break;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
