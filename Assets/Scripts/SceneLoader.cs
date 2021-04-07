using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    // Start is called before the first frame update
    bool lvlChange = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            lvlChange = true;
        }
        
    }
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlChange)
        {
            LoadNextScene();
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextScene()
    {
        
        SceneManager.LoadScene(currentSceneIndex + 1);
        lvlChange = false;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
