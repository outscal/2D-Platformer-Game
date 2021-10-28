using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button levelBtn;
    public string levelName;

    private void Awake()
    {
        levelBtn = GetComponent<Button>();
        levelBtn.onClick.AddListener(onlevelBtnClick); 
    }

    public void onlevelBtnClick()
    {
        // checking the levelStatus
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cant play this level till you unlock it!");
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
