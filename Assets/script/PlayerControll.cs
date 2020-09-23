using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private void Awake(){
        Debug.Log("Player controller");
    }
    private void OnCollisionEnter(Collision collision)

    {
        
        Debug.Log("collision:"+collision.gameObject.name);
        if (collision is null)
        {
            throw new System.ArgumentNullException(nameof(collision));
        }
       
    }
}
