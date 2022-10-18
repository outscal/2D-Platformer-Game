using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMainmenu;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        buttonRestart.onClick.AddListener(RestartButton);
        buttonMainmenu.onClick.AddListener(MainMenuButton);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level01");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
