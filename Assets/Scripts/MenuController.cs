using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject LevelUI;

    public void GameStart()
    {
        LevelUI.SetActive(true);
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    public void Quit()
    {
        Application.Quit();
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }
    
    public void Info()
    {
        SceneManager.LoadScene("Info");
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.Play(SoundManager.Sounds.ButtonClick);
    }
}
