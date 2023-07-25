using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Destroy : MonoBehaviour
{
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {

            collision.gameObject.GetComponent<Animator>().SetBool("Death", true);

            Destroy(collision.gameObject, 2f);
            StartCoroutine(LoadSceneAfterDelay(2f));
            
           
        }
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
