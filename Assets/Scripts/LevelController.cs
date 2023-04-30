using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private const string scene1 = "Level1";
    private const string scene2 = "Level2";
    private const string scene3 = "Level3";
    private const string scene4 = "Level4";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(SceneManager.GetActiveScene().name == scene1){
            if(other.gameObject.GetComponent<PlayerController>()){
                SceneManager.LoadScene(scene2);
            }
        }
        else if(SceneManager.GetActiveScene().name == scene2){
            if(other.gameObject.GetComponent<PlayerController>()){
                SceneManager.LoadScene(scene3);
            }
        }
        else if(SceneManager.GetActiveScene().name == scene3){
            if(other.gameObject.GetComponent<PlayerController>()){
                SceneManager.LoadScene(scene4);
            }           
        }
        else if(SceneManager.GetActiveScene().name == scene4){
            Debug.Log("Great Job! You have finished the game!");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
