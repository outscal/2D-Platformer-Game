using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elle2D
{
    //when player touches key this fun will work
    public class CollectKeyController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.PickUpKey();
                Destroy(gameObject);
            }
        }
    }

}
