using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelOverController : MonoBehaviour
{
    public string loadLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
            {
             Debug.Log("Level finished by the player");
           // LevelManage.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            SceneManager.LoadScene(loadLevel);
            //Debug.Log("level completed");
            LevelManage.Instance.MarkCurrentLevelComplete();
           // SceneManager.LoadScene("Lobby");
            }
    }
}
