using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCleared : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level cleared By Player");
        }

       UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        LevelManager.instance.MarklevelComplete();
    }

}
