using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level is Over");
            SceneManager.LoadSceneAsync(1);
        }
    }
}
