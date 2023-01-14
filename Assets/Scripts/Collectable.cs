using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Score score;

    private void Start()
    {
        score = GameObject.Find("Canvas").GetComponent<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            score.UpdateScore(5);
        }
    }
}
