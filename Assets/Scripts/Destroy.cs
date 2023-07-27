using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Destroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();

        if(playerController != null)
        {

            playerController.DeathAnimationPlay();
            Destroy(collision.gameObject, 2f);
            StartCoroutine(LoadSceneAfterDelay(2f));
            
           
        }
    }

    //Delays the Load scene
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
