using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] Transform levelSelectionParerent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.PlayerSound(Sounds.CompleteLevel);
            LevelManager.Instance.MarkCompleted();
            GameObject prefab =  Instantiate(LevelManager.Instance.LevelSelectionScreen);
            prefab.transform.SetParent(levelSelectionParerent,false);
        }
    }

    public void LevelReload()
    {
        SoundManager.Instance.PlayerSound(Sounds.StartingLevel);
        int current_scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene);

    }
}
