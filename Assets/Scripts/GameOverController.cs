using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    
    public Button RestartButton;
    private void Awake(){
        RestartButton.onClick.AddListener(ReloadLevel);
        
    }
    public void PlayerDied(){
              gameObject.SetActive(true);
    }
    public void ReloadLevel(){
        Scene scene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    

}
