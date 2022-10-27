using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_player : MonoBehaviour
{
    [SerializeField] private float damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
           
        }
      
    }
}
