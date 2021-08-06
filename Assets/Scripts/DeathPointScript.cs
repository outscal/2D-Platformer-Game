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
    public ParticleEffectController particleEffectController;

    // public object LobbyScene { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        btnRestartGame.onClick.AddListener(ReloadScene);
        btnLobby.onClick.AddListener(BackToLobby);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            SoundManager.Instance.Play(Sounds.PlayerDeath);
            DeathPanel.SetActive(true);
            particleEffectController.PlayFailingLevel();
             Destroy(collision.gameObject);
        }
    }

    public void ReloadScene()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        DeathPanel.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void BackToLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        print("Lobby Button is clicked");
        DeathPanel.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }


}
