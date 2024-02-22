using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public Animation Run_Anime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")>0)
        {
            speed = 1;
            Debug.Log("You have pressed D or A key ");
            Run_Anime.Play();
        }
    }
}
