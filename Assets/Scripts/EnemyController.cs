using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public HeartSystem heartSystem; 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            heartSystem.TakeDamage(1);              //  killPlayer()
        }

    }
}
