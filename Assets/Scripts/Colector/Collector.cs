using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject LevelEdnUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            LevelEdnUI.SetActive(true);
            LevelEdnUI.GetComponent<Animator>().Play("MoveIn");
            collision.gameObject.SetActive(false);
          
           LevelManager.instance.MarklevelComplete();
           
           
        }
    }
}
