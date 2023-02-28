using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Level {
    public class KeyController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.GetComponent<PlayerController>() != null) {
                PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                playerController.PickUpKey();

                // Destroy Key
                Destroy(gameObject);
            }
        }
    }
}

