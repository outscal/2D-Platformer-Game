using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerDead : MonoBehaviour
{
    public Animator animator;
    
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player Dead");
                animator.SetBool("Death", true);
                StartCoroutine(DelayDeathAnimation());
                ReloadScene();
            }
            else
            {
                animator.SetBool("Death", false);
            }
        }
  
    

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
     IEnumerator DelayDeathAnimation()
    {
        // Delay before starting the death animation
        yield return new WaitForSeconds(4);

        // Play the death animation here
        // ...
    }
}
