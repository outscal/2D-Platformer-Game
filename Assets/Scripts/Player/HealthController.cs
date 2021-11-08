using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthController : MonoBehaviour
{
    public PlayerController playerController;

    public Image[] lives; 
    private int livesCount = 3;

    public void LoseLife()
    {
        livesCount--;
        
        if(livesCount > 0)
        {
            lives[livesCount].gameObject.SetActive(false);
            
            SoundManager.Instance.Play(SoundManager.Sounds.ChomperEnemyCollision);

            if (livesCount == 0)
            {
                lives[livesCount].gameObject.SetActive(false);

                playerController.KillPlayer();
            }
        }
    }
}
