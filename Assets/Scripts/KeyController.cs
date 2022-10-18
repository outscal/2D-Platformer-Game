using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller player_controller = collision.gameObject.GetComponent<Player_Controller>();
            player_controller.PickUpKeys();
            Destroy(gameObject);
        }
    }
}
