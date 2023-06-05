using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOverController : MonoBehaviour
{
    public GameObject levelcompletemenu;
    public GameObject levelFinished;
    public Button buttonReplay;
    public Button nextLevel;
    public Button buttonExit;

    void Start()
    {
        buttonReplay.onClick.AddListener(ReplayLevel);
        buttonExit.onClick.AddListener(ExitToLobby);
        nextLevel.onClick.AddListener(UnlockNextLevel);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            levelcompletemenu.SetActive(true);
            Debug.Log("Level finished by the Player");
        }
    }

    public void LevelFinished()
    {
        levelFinished.SetActive(true);
    }
    public void UnlockNextLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickStart);
        LevelManager.Instance.MarkCurrentLevelComplete();
    }

    private void ReplayLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickConfirm);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    private void ExitToLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        SceneManager.LoadScene(0);
    }
}