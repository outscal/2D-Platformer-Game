using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlovercontroller : MonoBehaviour
{
    public void Awake()
    {
        Debug.Log("wE ARE READY");
    }
    public string ellencontrol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<playercontrolnew>() != null)
        {
            SceneManager.LoadScene(ellencontrol);
            Debug.Log("Level Finished");
        }
    }

}
