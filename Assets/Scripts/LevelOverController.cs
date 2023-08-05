using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private int SceneID = 1;
    [SerializeField] private float TimeDelay = 2f;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Debug.Log(" Level Finished by the Player ");
            Debug.Log(" Load New Level ");
            Invoke("Load_Scene", TimeDelay);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Deathpit"))
        {
            Debug.Log("Player Died");
            animator.SetTrigger("Death");
            Invoke("Load_Scene", TimeDelay);
        }
        
    }

    private void Load_Scene()
    {
        SceneManager.LoadScene(SceneID);
    }
}
