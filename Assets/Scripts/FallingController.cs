using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
