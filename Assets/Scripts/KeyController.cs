using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            Debug.Log("Player got a key");
            collision.gameObject.GetComponent<PlayerControler>().IncreaseScore(10);
            Destroy(gameObject);
        }
    }
}
