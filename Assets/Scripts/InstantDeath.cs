using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantDeath : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Restart level
            PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
