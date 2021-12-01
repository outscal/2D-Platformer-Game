using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyspin : MonoBehaviour
{
    private int keyScore;
    private bool detect;
    private float alphaLevel=1f;
    private void Awake()
    {
       // detect = false;
    }
    private void Update()
    {
       /* if(detect)
        {
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, alphaLevel);
            alphaLevel -= 0.05f;
        }*/
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag == "Player")
        {
            Playercontroller player = collision.GetComponent<Playercontroller>();
            if(player!=null)
            {
                player.addKeyScore(10);
                detect = true;
                Destroy(this.gameObject,2.0f);
            }
            
        }*/
        if(collision.gameObject.GetComponent<Playercontroller>()!=null)
        {
            Playercontroller _playercontroller = collision.gameObject.GetComponent<Playercontroller>();
            _playercontroller.pickUpKey(10);
            Destroy(this.gameObject);
        }
    }
}
