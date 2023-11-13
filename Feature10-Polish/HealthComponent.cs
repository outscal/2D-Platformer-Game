using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerMovement.Health--;
            if (playerMovement.Health <= 0)
            {
                playerMovement.Destroy(gameObject);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3,7);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(3,7, false);
    }
}