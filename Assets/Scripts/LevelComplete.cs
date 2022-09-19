using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Level completed");
        sceneIndex++;
        if (sceneIndex == 3)
        {
            sceneIndex = 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
