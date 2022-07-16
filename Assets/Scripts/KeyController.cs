using UnityEngine;

public class KeyController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = (PlayerController)collider.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(gameObject);
        }
    }
}
