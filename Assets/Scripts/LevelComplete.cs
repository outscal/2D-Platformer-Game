using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Complete");
            LevelManager.Instance.setLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            LevelManager.Instance.MarkedLevelComplate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
