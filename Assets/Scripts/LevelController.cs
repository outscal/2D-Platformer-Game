using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            NextLevel();
        }
    }


    void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelReload()
    {
        int current_scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene);
    }

    public void LevelLoader()
    {

    }
}
