using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //level is over
            Debug.Log("Level Completed.");
            SceneManager.LoadScene(2);
        }
    }
}
