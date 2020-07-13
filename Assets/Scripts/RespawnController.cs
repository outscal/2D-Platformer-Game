using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField]Transform RespawnPoint;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()!= null)
        {
            collision.transform.position = RespawnPoint.transform.position;
        }
    }
}
