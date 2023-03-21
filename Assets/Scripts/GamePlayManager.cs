using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{

    public Button RestartButton;
    public Button quitButton;
    public GameObject GameOverPanel;

   
    private void Awake()
    {
        Time.timeScale = 1f;
        RestartButton.onClick.AddListener(RestartLevel);
        quitButton.onClick.AddListener(QuitLevel);
    }


   

    // How this AdliStern working Behind the scene ? why we cannot pass it as fucntion ? isnide the Adlisterner
    public void RestartLevel()
    {
       
        StartCoroutine(WiatAnimTime());
        GameOverPanelMoveOut();
     Scene  scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.buildIndex);
        
    }
    public void QuitLevel()
    {

      
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);


    }

    public void GameOverPanelMoveIn()
    {
        GameOverPanel.GetComponent<Animator>().Play("MoveIn");
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOverPanelMoveOut()
    {
        GameOverPanel.GetComponent<Animator>().Play("MoveOut");
        GameOverPanel.SetActive(false);
    }


    IEnumerator WiatAnimTime()
    {
        yield return new WaitForSeconds(2f);
    }
}
