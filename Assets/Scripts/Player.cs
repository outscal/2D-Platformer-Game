using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector3 originalPos; 
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -6.0f)
        {
            OnDeath(); 

        }
    }

    public void OnDeath()
    {

        Debug.Log(" Player has died");
        // reset player position 
        transform.position = originalPos; 


    }
}
