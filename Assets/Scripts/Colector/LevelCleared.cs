using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCleared : MonoBehaviour
{
    private GameObject LevelEdnUI;
    private Button QuitButton;
    private Button RestartButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level cleared By Player");
        }
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
