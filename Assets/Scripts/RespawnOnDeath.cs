using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnOnDeath : MonoBehaviour
{
    //[SerializeField] private Transform player;
    //[SerializeField] private Transform respawn;
         
      private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player dies on jump landing in gap");
            // player respawn on start position upon dying    
            SceneManager.LoadScene(0, LoadSceneMode.Single); 
         // player.transform.position = respawn.transform.position;
          
            //collision.gameObject.transform.position = collision.gameObject.GetComponent<PlayerController>().;
        }
    }

}
