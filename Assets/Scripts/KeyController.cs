using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Animator keyAnimator;

    private void Awake()
    {
        keyAnimator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject.GetComponent<PlayerController>() != null)
        {
            // key gameobject is destroyed before animation can play.
            keyAnimator.SetBool("isCollected", true);
            PlayerController playerController = (PlayerController)collider.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(gameObject);
        }
    }
}
