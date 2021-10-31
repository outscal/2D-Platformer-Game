using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<playerController>() !=null)
        {
            soundManager.Instance.Play(Sounds.pickUpCoin);
            playerController pc = collision.gameObject.GetComponent<playerController>();
            pc.PickUpKey();
            Destroy(gameObject);
           
        }
    }
}
