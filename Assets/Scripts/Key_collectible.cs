using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_collectible : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()!= null)
        {
            PlayerController playercollsion;
            playercollsion = collision.gameObject.GetComponent<PlayerController>();
            playercollsion.updateScore();
            Destroy(gameObject);
            Debug.Log(playercollsion.gameObject.name + "collected");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
