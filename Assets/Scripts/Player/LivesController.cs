using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LivesController : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Image[] lives; 
    private int livesCount = 3;

    public void LoseLife()
    {
        livesCount--;
        
        if(livesCount > 0)
        {
            lives[livesCount].gameObject.SetActive(false);

            if(livesCount == 0)
            {
                lives[livesCount].gameObject.SetActive(false);

                playerMovement.KillPlayer();
            }
        }
    }
}
