using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteController : MonoBehaviour
{
    public Animator animator;
    public GameOverController gameOverController;
    private bool Door = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Debug.Log("Level Complete");
            DoorAnimation(Door);
            Door = true;
            LevelManager.Instance.MarkCurrentLevelComplete();
            gameOverController.ReloadLevel();
        }
    }
    private void DoorAnimation(bool Door)
    {
        if(Door == true)
        {
            animator.SetBool("AnimDoor", true);
        }
        else
        {
            animator.SetBool("AnimDoor", false);
        }
    }
}
