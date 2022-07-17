using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantDeath : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Game Over.\n You have died.");
            //Restart level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Respawning...");
        }
    }
}
