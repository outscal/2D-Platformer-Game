using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject[] lives;
    int i = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementLives()
    {
        if(i>=0)
        {
            lives[i].gameObject.SetActive(false);
            i--;
        }
        
    }
}
