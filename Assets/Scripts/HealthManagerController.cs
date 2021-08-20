using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerController : MonoBehaviour
{
    public GameObject health1, health2, health3;

    public int healthCounter = 3;

    private void Start()
    {
        print("Initial Player Health Counter is " + healthCounter);

    }

   

    public void DecreaseHealth()
    {
        
        print("healthCounter " + healthCounter);
        if (healthCounter == 3)
        {
            health3.SetActive(false);
        }
        else if (healthCounter == 2)
        {
            health2.SetActive(false);
        }
        else if (healthCounter == 1)
        {
            health1.SetActive(false);
            Debug.Log("Player Run Out of Life");
        }
        else
        {
            healthCounter = 0;
        }
        healthCounter--;
    }

}
