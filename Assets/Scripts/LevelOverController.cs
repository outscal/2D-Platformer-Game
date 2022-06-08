using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public int totalLevels = 2;
    public Transform levelBegin;
    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if (transform.gameObject.CompareTag("Finish"))
            {
                Debug.Log("Level Complete!");
                // Load the next level, however loop back from last level to level 1.
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1)% totalLevels);

            }
            else if (transform.gameObject.CompareTag("FailZone"))
            {
                Debug.Log("Level Failed!");
                collision.gameObject.transform.position = levelBegin.position;
                Debug.Log("Respawned!");
            }
        }
        
    }
}
