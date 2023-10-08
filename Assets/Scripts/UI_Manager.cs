using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver_Panel;
    [SerializeField]
    private GameObject[] hearts;
    [SerializeField]
    private GameObject levelComplete;
    [SerializeField]
    private GameObject pausedPanel;
    [SerializeField]
    private Animator uiAnim;

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
        pausedPanel.SetActive(false);
        GameOver_Panel.SetActive(false);
        levelComplete.SetActive(false);
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
    public void LevelComplete()
    {
        levelComplete.SetActive(true);
        playerController.instance.enabled = false;
    }
    public void GameOver()
    {        
        GameOver_Panel.SetActive(true);
        uiAnim.SetTrigger("GameOver");
        Time.timeScale = 0f;
        Debug.Log(" Gameover time paused");
    }
    
    private void GamePasued()
    {
        pausedPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Debug.Log("Game restared time started too");
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pausedPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GamePasued();
        }
    }

}
