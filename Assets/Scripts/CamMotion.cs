using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMotion : MonoBehaviour
{
     GameObject player;
    Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
         player = FindObjectOfType<Player>().gameObject;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        temp = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = temp;

     //   transform.LookAt(player.transform); 
    }


}
