using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyspin : MonoBehaviour
{
    private int keyScore;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Playercontroller player = collision.GetComponent<Playercontroller>();
            if(player!=null)
            {
                player.addKeyScore(10);
               // keyScore++;
               // Debug.Log("Key Score :"+keyScore);
               
                Destroy(this.gameObject);
            }
            
        }
    }
}
