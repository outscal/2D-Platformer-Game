using UnityEngine;

public class GameOver_collisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collison detected with the gameover..");
            if (other.gameObject.CompareTag("Player"))
            {          
              if (UI_Manager.Instance != null)
              {
                SoundManager.Instance.LowVolSFXSounds(SoundTypes.GameOver);
                UI_Manager.Instance.GameOver();
              }
            }
    }

}
