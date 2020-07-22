using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject[] lives;
    int i = 2;
    public void DecrementLives()
    {
        if(i>=0)
        {
            lives[i].gameObject.SetActive(false);
            i--;
        }
        
    }
}
