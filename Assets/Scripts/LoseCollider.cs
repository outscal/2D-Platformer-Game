using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour
{
    public SceneLoader sceneLoader;
    int currentSceneIndex;
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision detected");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            sceneLoader.ReloadScene();
        }
    }
}
