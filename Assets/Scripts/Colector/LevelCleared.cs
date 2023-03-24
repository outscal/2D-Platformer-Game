using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCleared : MonoBehaviour
{
    public GameObject LevelEdnUI;
    public Button QuitButton;
    public Button RestartButton;
    public GameObject particleEffect;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level cleared By Player");
        }
        Instantiate(particleEffect, player.transform.position, Quaternion.identity);
        SoundManager.Instance.PlaySounds(Sounds.LevelCleared);
        LevelEdnUI.SetActive(true);
        LevelEdnUI.GetComponent<Animator>().Play("MoveIn");


    }



    public void RestartGameButton()
    {
        LevelEdnUI.GetComponent<Animator>().Play("MoveOut");
        LevelEdnUI.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        LevelManager.instance.MarklevelComplete();

    }
    public void QuitGameButton()
    {
        LevelEdnUI.GetComponent<Animator>().Play("MoveOut");
        LevelEdnUI.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        LevelManager.instance.MarklevelComplete();
    }

}
