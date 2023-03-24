using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyColectable : MonoBehaviour
{
    public KeyAnimation keyAnim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keyAnim.SetFlag(true);
           // this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<PlayerController>().KeyCollected();

        }
    }



}
