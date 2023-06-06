using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonReplay;
    public Button buttonExit;
    public GameObject GameOvermenu;
    public Animator animator;
    public PlayerHealth playerHealth;
    public ParticleSystem Particlesystem;
    public float deathParticleMultiplier = 2f;


    void Awake()
    {
        buttonReplay.onClick.AddListener(ReplayLevel);
        buttonExit.onClick.AddListener(ExitToLobby);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playerHealth.health = 0;
            Debug.Log("Player Fall Dead");
            animator.SetTrigger("Death");
            SoundManager.Instance.PlayMusic(Sounds.LevelFailed);

            ParticleSystem.MainModule mainModule = Particlesystem.main;
            mainModule.startColor = Color.black;

            Particlesystem.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

            ParticleSystem.EmissionModule emission = Particlesystem.emission;
            emission.rateOverTimeMultiplier *= deathParticleMultiplier;

            Invoke("PlayerDied", 4f);
        }
    }

    public void PlayerDied()
    {
        GameOvermenu.SetActive(true);
    }

    private void ReplayLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickStart);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    private void ExitToLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClickBack);
        SceneManager.LoadScene(0);
    }
}
