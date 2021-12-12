using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
    //  public int iLevelToLoad;
    // public string sLevelToLad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
       // if (collision.gameObject.GetComponent<Player_controller>() != null)
        {
        //level is completed
          Debug.Log("Level 1 is finished by player");
    }
    // {
    // if (collision.gameObject.CompareTag("Player"))
    // if (collision.gameObject.GetComponent<Player_controller>() != null)
    //  {
    // level is completed
    // Debug.Log("Level 1 is finished by player");
}
      }

