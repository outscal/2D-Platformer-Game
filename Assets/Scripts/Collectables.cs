using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectables : MonoBehaviour
{
    [SerializeField] int value = 0;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player collected {gameObject.name}");
           
            collision.GetComponent<PlayerController>().PickUpCollectables(value);
            gameObject.SetActive(false);
        }
    }
}
