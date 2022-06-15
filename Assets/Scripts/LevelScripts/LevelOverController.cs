using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public int totalLevels = 3;
    public Transform levelBegin;
    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            
                Debug.Log("Level Complete!");
                // Load the next level, however loop back from last level to level 1.
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
        
    }
}
