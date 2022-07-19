using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantDeath : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Restart level
            collision.gameObject.GetComponent<PlayerController>().KillPlayer();
        }
    }
}
