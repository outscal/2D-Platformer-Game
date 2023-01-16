using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{
    private Button button;
    public int buildNumber;

    private void Start()
    {
        button = GetComponent<Button>();
        if(button == null)
        {
            Debug.Log("button missing");
        }

        button.onClick.AddListener(GameStart);
    }
    private void Update()
    {
        QuitEsc();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    void QuitEsc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(buildNumber);
    }
}
