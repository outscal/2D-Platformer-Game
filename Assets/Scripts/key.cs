using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class key : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player.KeyPickUp();
            Destroy(this.gameObject);
        }
    }
}
