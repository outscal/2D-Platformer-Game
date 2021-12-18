using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    public PlayerController playerController;

    public Image[] LivesCount;
    private int LivesRemaning = 3;

    public void LoseLife()
    {
        if(LivesRemaning > 0)
        {
            LivesCount[--LivesRemaning].enabled = false;
            if (LivesRemaning == 0)
            {
                playerController.KillPlayer();
            }
        }
    }       
}
