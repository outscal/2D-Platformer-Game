using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelOverController : MonoBehaviour
{
    GameManager gm;
    public int nextLevel;
    

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            gm.LoadNextLevel(nextLevel);
        }
    }


     void Start()
    {
       gm = FindObjectOfType<GameManager>();
    }
}
