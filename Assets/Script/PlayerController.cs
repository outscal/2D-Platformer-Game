using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;

    //Collider Variables
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    public float speed;

    private void Start()
    {
        //Fetching initial collider properties
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        PlayMovementAnimation(horizontal);

        float VerticalInput = Input.GetAxis("Vertical");

        PlayJumpAnimation(VerticalInput);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
        }
        else
        {
            Crouch(false);
        }

    }

    private void PlayMovementAnimation(float horizontal)
    {

        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }

        if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    public void Crouch(bool crouch)
    {
        if (crouch == true)
        {
            float offX = -0.12494f;     //Offset X
            float offY = 0.61027f;      //Offset Y

            float sizeX = 0.8923f;     //Size X
            float sizeY = 1.3452f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        //Play Crouch animation
        playerAnimator.SetBool("Crouch", crouch);
    }

    public void PlayJumpAnimation(float vertical)
    {
        if (vertical > 0)
        {
            playerAnimator.SetTrigger("Jump");
        }
    }
}
