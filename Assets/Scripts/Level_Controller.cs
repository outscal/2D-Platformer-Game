using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Level_Controller : MonoBehaviour
{
    public GameObject endText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() !=null)
        {
            StartCoroutine(LoadSceneDelay(2));
            endText.SetActive(true);
        }
    }

    //Delay the current scene when it collides with the trigger
    private IEnumerator LoadSceneDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
