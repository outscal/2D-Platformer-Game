using UnityEngine;

public class GameOver_collisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collison detected with the gameover..");
            if (other.gameObject.CompareTag("Player"))
            {          
              if (UI_Manager.instance != null)
              {
                UI_Manager.instance.HandleCollisionWithPlayer();
              }
            }
    }

}
