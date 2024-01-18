using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    private int playerScore;
    [SerializeField] private bool lvl2 = false;
    private bool lvl3 = false;

    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("LevelManager");
                    _instance = singletonObject.AddComponent<LevelManager>();
                }

                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (activeSceneIndex == 0)
        {
            // Find the Canvas in the scene
            Canvas canvas = FindObjectOfType<Canvas>();

            if (canvas != null)
            {
                // Find the buttons using the canvas hierarchy
                Transform emptyGameObject = canvas.transform.Find("levelSelectionScreen");
                Button lvl2Button = emptyGameObject?.Find("Panel/Button2")?.GetComponent<Button>();
                Button lvl3Button = emptyGameObject?.Find("Panel/Button3")?.GetComponent<Button>();

                if (lvl2)
                {
                    lvl2Button.gameObject.SetActive(true);
                    if (lvl3)
                    {
                        lvl3Button.gameObject.SetActive(true);
                    }
                    else
                    {
                        lvl3Button.gameObject.SetActive(false);
                    }
                }
                else
                {
                    lvl2Button.gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.LogError("Canvas not found in the scene.");
            }
        }
        else if (activeSceneIndex == 2)
        {
            lvl2 = true;
            UpdatePlayerScore();
        }
        else if (activeSceneIndex == 3)
        {
            lvl3 = true;
            UpdatePlayerScore();
        }

        Debug.Log("Scene loaded: " + scene.name);
    }

    public void UpdatePlayerScore()
    {
        TMP_Text scoreText = FindObjectOfType<TMP_Text>();

        if (scoreText != null)
        {
            Player playerScript = FindObjectOfType<Player>();
            playerScript.SetScoreText(playerScore);
            scoreText.text = "Score: " + playerScore.ToString();
        }
        else
        {
            Debug.LogError("Score Text component not found in the scene.");
        }
    }

    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}