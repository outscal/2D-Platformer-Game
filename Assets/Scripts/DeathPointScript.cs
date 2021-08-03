using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPointScript : MonoBehaviour
{
    public GameObject DeathPanel;
    public Button btnRestartGame;
    public Button btnLobby;
    public string sceneName;

   // public object LobbyScene { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        btnRestartGame.onClick.AddListener(ReloadScene);
        btnLobby.onClick.AddListener(BackToLobby);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            DeathPanel.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    public void ReloadScene()
    {
        DeathPanel.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void BackToLobby()
    {
        print("Lobby Button is clicked");
        DeathPanel.SetActive(false);

        SceneManager.LoadScene(sceneName);
    }


}
