using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlovercontroller : MonoBehaviour
{
    public void Awake()
    {
        Debug.Log("wE ARE READY");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<playercontrolnew>() != null)
        {
            Debug.Log("Level Finished");
        }
    }


}
