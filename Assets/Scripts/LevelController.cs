using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string NextScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(NextScene);
            Debug.Log("collided with player");
        }
    }
    // Start is called before the first frame update
/*    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
