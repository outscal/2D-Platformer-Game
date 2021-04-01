using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Start is called before the first frame update
    bool lvlChange = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lvlChange = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlChange)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
