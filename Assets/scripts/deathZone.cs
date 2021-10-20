using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    [SerializeField] Transform Respwanner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<playerController>() != null)
        {
            playerController pc = collision.gameObject.GetComponent<playerController>();
            pc.LoosePlayerLIfe();
            pc.transform.position = Respwanner.position;
            

        }
    }
}
