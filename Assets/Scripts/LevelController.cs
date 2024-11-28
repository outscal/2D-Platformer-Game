using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            Debug.Log("Level finished");
            //UnlockNewLevel();
            LevelManager.Instance.SetCurrentLevelComplete();
            SoundController.Instance.Play(Sounds.ButtonClick);
            SceneController.instance.nextLevel();
        }
    }



}



