using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public Animator animator;
    bool isCrouching = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            Debug.Log("key was pressed");        
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
        }
        animator.SetBool("Crouch", isCrouching);
    }
}
