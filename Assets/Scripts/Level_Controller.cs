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
            SceneManager.LoadScene(0);
            endText.SetActive(true);
        }
    }
}
