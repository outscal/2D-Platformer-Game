using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteScreen;

    private void Start()
    {
        levelCompleteScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            levelCompleteScreen.SetActive(true);
        }
    }
}
