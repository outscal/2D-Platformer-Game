using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;


public class GamePlayManager : MonoBehaviour
{

    public Button RestartButton;

    public GameObject GameOverPanel;

   
    private void Awake()
    {
        Time.timeScale = 1f;
        RestartButton.onClick.AddListener(RestartLevel);

    }


   

    // How this AdliStern working Behind the scene ? why we cannot pass it as fucntion ? isnide the Adlisterner
    public void RestartLevel()
    {
       
        StartCoroutine(WiatAnimTime());
        GameOverPanelMoveOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
        
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
