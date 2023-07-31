using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Level_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject endText;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() !=null)
        {
            ReloadScene(1f);
            endText.SetActive(true);
        }
    }

    //Reload Function
    public void ReloadScene(float seconds)
    {
        Invoke(nameof(LoadScene), seconds);
    }

    //Delays the Load scene
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

}
