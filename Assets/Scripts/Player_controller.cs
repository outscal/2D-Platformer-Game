using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{

    public GameObject player;
    public float player_speed;
    public Animator animatior;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        Debug.Log(speed);
        animatior.SetFloat("Speed",Mathf.Abs(speed));
        if(speed<0)
        {
            Vector2 Scale = transform.localScale;
            Scale.x = -1;
            transform.localScale = Scale;
        }
        else if(speed>0)
        {
            Vector2 Scale = transform.localScale;
            Scale.x = 1;
            transform.localScale = Scale;
        }
        //player.transform.localScale = new Vector3(speed, player_speed, 0);
    }
}
