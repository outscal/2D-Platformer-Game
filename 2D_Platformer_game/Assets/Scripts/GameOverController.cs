using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(ReloadScene);
    }
   public void Playerdied()
   {
       gameObject.SetActive(true);
   }

   public void ReloadScene()
    {
        
        SceneManager.LoadScene("Start");
    }
}
