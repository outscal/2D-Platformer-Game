using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Elle2D
{
    public class BomberScript : MonoBehaviour
    {
        [SerializeField] float speed = 0.1f;
        [SerializeField] public Rigidbody2D rb;

        void Start()
        {
            rb.velocity = transform.right * -speed;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            PlayerController player = collider.GetComponent<PlayerController>();
            if (player != null)
            {
                player.KillPlayer();
                gameObject.SetActive(false);
            }
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

    }
}