using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper_enemy_interaction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player_controller>()!=null)
        {
            collision.GetComponent<Player_controller>().ifdead();
        }
    }
}
