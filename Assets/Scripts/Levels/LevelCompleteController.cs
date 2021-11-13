using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour
{
    public Animator animator;
    public GameObject LevelComplete;
    public Button reloadLevel;
    //public Button nextLevel;
    public Button mainMenu;
    public GameOverController gameOverController;
    private bool Door = true;
    private void Awake()
    {
        reloadLevel.onClick.AddListener(ReloadLevel);
        mainMenu.onClick.AddListener(MainMenu);
        //nextLevel.onClick.AddListener(NextLevel);
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }
    private void MainMenu()
    {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene(0);
    }
    private void ReloadLevel()
    {
        Debug.Log("Reloading current level");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("Level Complete");
            DoorAnimation(Door);
            Door = true;
            LevelManager.Instance.MarkCurrentLevelComplete();
            LevelComplete.SetActive(true);
        }
    }
    private void DoorAnimation(bool Door)
    {
        if(Door == true)
        {
            animator.SetBool("AnimDoor", true);
        }
        else
        {
            animator.SetBool("AnimDoor", false);
        }
    }
}
