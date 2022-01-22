using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public Image[] lives; 
    private int livesCount = 3;

    public void LoseLife()
    {
        livesCount--;
        
        if(livesCount > 0)
        {
            playerController.DamagePlayer();

            lives[livesCount].gameObject.SetActive(false);

            if (livesCount == 0)
            {
                playerController.KillPlayer();

                lives[livesCount].gameObject.SetActive(false);
            }
        }
    }
}
