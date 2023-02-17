using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private BoxCollider2D playerBoxCollider;
    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(speed < 0){
            scale.x = -1f * (Mathf.Abs(scale.x));
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
        float upforce = Input.GetAxisRaw("Vertical");
        if(upforce > 0)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);

        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            bool isCourching = playerAnimator.GetBool("Crouch");
            playerAnimator.SetBool("Crouch", !isCourching);
            isCourching = playerAnimator.GetBool("Crouch");
            Vector2 size = playerBoxCollider.size;
            Vector2 offset = playerBoxCollider.offset;
            if (isCourching)
            {
                size.y /= 2f;
                offset.y /= 2f;
            }else
            {
                size.y *= 2f;
                offset.y *= 2f;
            }
            playerBoxCollider.size = size;
            playerBoxCollider.offset = offset;
        }
    }
}
