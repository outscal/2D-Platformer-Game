using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Animator animator;
    private bool KeyAchieved;
    private void KeyMovementAnimation(bool KeyAchieved)
    {
        //Vanish Key Animation
        if (KeyAchieved==true)
        {
            animator.SetBool("AnimKeyAchieved", true);
            Debug.Log("Animation of Key Achievement Began");
        }
        else
        {
            animator.SetBool("AnimKeyAchieved", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpKey();
            KeyAchieved = true;
            KeyMovementAnimation(KeyAchieved);
            Destroy(gameObject);
        }
    }
}
