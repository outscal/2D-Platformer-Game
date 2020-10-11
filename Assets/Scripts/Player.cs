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
       
    }

    
    public void OnDeath()
    {

        Debug.Log(" Player has died");
        // reset player position 
        PlayerInit(); 


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BottomMark")
        {

            OnDeath(); 
        }
    }
    public void PlayerInit()
    {
        transform.position = originalPos;

    }
}
