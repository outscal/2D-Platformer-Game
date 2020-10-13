using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMotion : MonoBehaviour
{
     GameObject player;
    Vector3 newDirection;
    // Start is called before the first frame update
    void Start()
    {
         player = FindObjectOfType<Player>().gameObject;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newDirection = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = newDirection;
            //https://answers.unity.com/questions/36255/lookat-to-only-rotate-on-y-axis-how.html//

        // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);

        transform.LookAt(player.transform); 
    }


}
