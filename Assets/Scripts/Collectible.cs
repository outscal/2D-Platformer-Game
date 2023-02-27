using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(  collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpCollectibe();
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
