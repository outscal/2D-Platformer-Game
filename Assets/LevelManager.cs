using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int LevelsUnlocked;

    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        LevelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked",1);

        for(int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i < LevelsUnlocked; i++) 
        {
            buttons[i].interactable = true;
        }
    }

    public void  LoadLevel(int levelIndex)
    {
           SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
