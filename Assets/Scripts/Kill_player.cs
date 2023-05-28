using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Kill_player : MonoBehaviour
{
    public Transform spawn;
    public GameObject player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            Vector3 spawn_point = spawn.position;
            Destroy(collision.gameObject);
            Instantiate(player,spawn_point,Quaternion.identity);
            lives_system.lives_decrease();
        }
    }
}
