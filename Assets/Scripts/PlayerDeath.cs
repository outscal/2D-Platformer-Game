using UnityEngine;

public class PlayerDeath : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
            // player respawn on start position upon dying    
            // PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            // playerController.KillPlayer();
            Destroy(gameObject);
    }
}
