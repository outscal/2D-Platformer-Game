using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Animator keyAnimator;
    private bool isKeyReadyToMove = false;

    private void Awake()
    {
        keyAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isKeyReadyToMove)
            MoveKeyUpwards();
    }
    private void MoveKeyUpwards()
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.y += 2 * Time.deltaTime;
        transform.position = position;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject.GetComponent<PlayerController>() != null)
        {
            // key gameobject is destroyed before animation can play.
            keyAnimator.SetBool("isCollected", true);
            //move key upwards
            isKeyReadyToMove = true;
            PlayerController playerController = (PlayerController)collider.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            Destroy(gameObject, 0.5f);
        }
    }
}
