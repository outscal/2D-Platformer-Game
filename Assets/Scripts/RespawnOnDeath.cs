using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnOnDeath : MonoBehaviour
{

    public HeartSystem heartSystem;
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player dies on jump landing in gap"); 
            heartSystem.TakeDamage(1);
            playerController.FindStartPos();
            SoundManager.Instance.Play(Sounds.Fall);
        }
    }

}
