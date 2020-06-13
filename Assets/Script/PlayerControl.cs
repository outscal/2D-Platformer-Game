using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player_Object;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            player_Object.GetComponent<Animator>().SetFloat("speed",0.6f);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            player_Object.GetComponent<Animator>().SetFloat("speed", 0.3f);
        }
    }
}
