using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
   [SerializeField] private Button button;
    [SerializeField] GameObject LevelSlectionPanel;
    void Awake()
    {
        LevelSlectionPanel.SetActive(false);
        button.onClick.AddListener(OpenPanel);

    }

   
    private void OpenPanel()
    { 
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSlectionPanel.SetActive(true);
    }
     public void LevelBtn(string sceneName)
    {
       
        LevelStatus levelStatus = LevelManager.Instacne.GetLevelStatus(sceneName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't Play this Level");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(sceneName);
                break;

            case LevelStatus.Complete:
                SceneManager.LoadScene(sceneName);
                break;
        }
    }

    public void Exit()
    {
         SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("Game is Exit");
        Application.Quit();

    }
}
