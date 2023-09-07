using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ToLv2")
        {
            Debug.Log("Collision detected");
            SceneManager.LoadScene(1);
        }
    }

}
