using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Game's Started");
        }
    }
}
