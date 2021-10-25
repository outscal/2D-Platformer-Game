using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarController : MonoBehaviour
{
   float health = 100;
    int numberOFLives = 3;
    [SerializeField] GameObject[] heelthUI;
    [SerializeField]Image healthBar;
    public playerController pc;
    public void ChangeHealth(int damage )
    {
        health -= damage;
        Debug.Log(health);
        if(health<=0)
        { health = 100;
          LoosePlayerLIfe();
        }
        RefeshUI();
    }
    private void RefeshUI()
    {
        healthBar.fillAmount = health / 100;
    }
    public void LoosePlayerLIfe()
    {

        healthController hc;
        numberOFLives -= 1;
        if (numberOFLives >= 0)
        {
            hc = heelthUI[numberOFLives].GetComponent<healthController>();
            hc.looseHeart();


        }



        if (numberOFLives <= 0)
        {
            pc.KillPlayer();
        }


    }
}
