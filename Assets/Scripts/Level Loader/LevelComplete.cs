using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("level Complete");
        }
    }
}
