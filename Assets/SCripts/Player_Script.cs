using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Player_Anime(horizontal);
        Player_Move(horizontal);
    }

    private void Player_Move(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void Player_Anime(float horizontal)
    {
        animator.SetFloat("SPEED", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontal > 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;

        bool vertical = Input.GetKey(KeyCode.Space);
        animator.SetBool("JUMP", vertical);

        bool Crounch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("CROUNCH", Crounch);
    }
}
