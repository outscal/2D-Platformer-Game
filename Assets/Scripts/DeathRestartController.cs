using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRestartController : MonoBehaviour
{
    
    public Animator animator;
    public int SceneID = 0;
    public float TimeDelay = 2f;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Deathpit"))
        {
            Debug.Log("Player Died");
            animator.SetTrigger("Death");
            Invoke("LoadScene", TimeDelay);
        }
        
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneID);
    }

}
