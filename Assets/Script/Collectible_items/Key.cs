using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private int Keys = 0;
    private int Score = 0;

    [SerializeField] private Text KeyText;
    [SerializeField] private Text ScoreText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            Keys++;
            KeyText.text = "Keys: " + Keys;
            Score += 10;
            ScoreText.text = "Score: " + Score;
        }
      
    }
}
