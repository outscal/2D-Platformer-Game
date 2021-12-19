using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    public PlayerController playerController;
    public ParticleController playerDeath;

    public Image[] LivesCount;
    private int LivesRemaning = 3;

    public void LoseLife()
    {
        if(LivesRemaning > 0)
        {
            LivesCount[--LivesRemaning].enabled = false;
            SoundManager.Instance.Play(SoundManager.Sounds.EnemyCollision);
            if (LivesRemaning == 0)
            {
                playerDeath.PlayEffect();
                playerController.KillPlayer();
            }
        }
    }       
}
