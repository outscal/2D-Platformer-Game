using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
 private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("FallingDown"))
        {
            PlayerDie();
        }
    }
    private void PlayerDie()
    {
        rgbd2d.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
        
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
