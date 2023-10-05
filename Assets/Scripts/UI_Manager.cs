using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver_Panel;
    [SerializeField]
    private GameObject[] hearts;
    public Animator uiAnim;

    public static UI_Manager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        UpdatehealthOnUI();
        //GameOver_Panel.SetActive(false);
    }

    public void UpdatehealthOnUI()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<playerController.instance.playerHealth)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
        
    }
    public void GameOver()
    {
        uiAnim.SetTrigger("GameOver");
        //GameOver_Panel.SetActive(true);        
        Time.timeScale = 0;
        Debug.Log(" Gameover time paused");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Debug.Log("Game restared time started too");
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
