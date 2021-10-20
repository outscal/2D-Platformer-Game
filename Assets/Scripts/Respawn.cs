using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnpoint;

    void OnTriggerEnter2D(Collider2D other){

        player.transform.position = respawnpoint.transform.position;
        Debug.Log("Player respawn");
    }
}
