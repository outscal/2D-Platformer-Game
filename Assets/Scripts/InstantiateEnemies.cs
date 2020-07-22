using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject HiddenEnemyPrefab;
    private float time;
    private void Awake()
    {
        time = Time.time;
    }
    
    void Update()
    {
        
            if (Time.time > time)
            {
                time += Random.Range(1, 17);
                Instantiate(HiddenEnemyPrefab, transform.position, Quaternion.identity);

            }
        
        
    }

    


}


    
