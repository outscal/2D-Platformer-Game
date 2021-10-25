using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    [SerializeField] Transform Respwanner;
    [SerializeField] healthBarController hbc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController pc = collision.gameObject.GetComponent<playerController>();
            hbc.ChangeHealth(100);
            pc.transform.position = Respwanner.position;
            

        }
    }
}
