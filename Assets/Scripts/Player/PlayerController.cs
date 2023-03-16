using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed;

    public Animator playerAnim;
    public Vector3 temp;
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Debug.Log(playerSpeed);
        Crouch();
    }


    public void PlayerMove()
    {

        playerSpeed = Input.GetAxis(HelperNames.HorizontalAxis);

        playerAnim.SetFloat("Speed", Mathf.Abs(playerSpeed));
        // Flip Player Left Right.......

        temp = this.transform.localScale;
        if (playerSpeed > 0)
        {
            temp.x = Mathf.Abs(temp.x);
        }
        else if (playerSpeed < 0)
        {
            temp.x = -1f * Mathf.Abs(temp.x);
        }

        this.transform.localScale = temp;


    }






    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))  // are all the key enum parameters in unity ??
        {

            playerAnim.SetTrigger("Crouch");
        }


    }



}
