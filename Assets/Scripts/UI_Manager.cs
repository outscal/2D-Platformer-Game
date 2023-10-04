using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver_Panel;
    public int playerHealth = 5;
    [SerializeField]
    private GameObject[] hearts;

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
        GameOver_Panel.SetActive(false);
    }

    public void UpdatehealthOnUI()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i< playerHealth)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
        
    }
    public void HandleCollisionWithPlayer()
    {
        Debug.Log("Setting Gameover to true");

        GameOver_Panel.SetActive(true);
        StartCoroutine(ResetGameCoroutine());
    }
    private IEnumerator ResetGameCoroutine()
    {
        // Waiting for a short delay before checking for the "R" key press
        yield return null;

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameOver_Panel.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            yield return null;
        }
    }

}
