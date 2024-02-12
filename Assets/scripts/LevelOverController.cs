using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverController : MonoBehaviour
{
   
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
    {
       // if(collision.gameObject.CompareTag("player"))
       if(collision.gameObject.GetComponent<NewBehaviourScript>()!=null)
        {
            Debug.Log("level finished by the player");
        }
    }
}
