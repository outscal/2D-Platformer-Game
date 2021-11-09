using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enemy");
        Playercontroller _player = collision.gameObject.GetComponent<Playercontroller>();
        if(_player != null)
        {
           
            _player.killPlayer();
        }
    }
}
