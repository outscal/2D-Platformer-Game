using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Level_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject endText;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() !=null)
        {
            StartCoroutine(LoadSceneAfterDelay(1f));
            endText.SetActive(true);
        }
    }

    //Delays the Load scene
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }

}
