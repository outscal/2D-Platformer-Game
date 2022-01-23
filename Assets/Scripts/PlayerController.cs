using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;

    public Animator anim;
    private float speed = 5f;
    private float jump = 50f;
    private Rigidbody2D rb;

    [SerializeField]
    private bool isCrouching=false;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);

        



    }

    public void PickUpKeys()
    {
        Debug.Log("Player picked up the key");
        scoreController.ScoreIncrease(10);
    }

    public void PlayerKill()
    {

        Destroy(gameObject);
        ReloadScene();

    }

    public void ReloadScene()
    {

        SceneManager.LoadScene(0);
    }


    public void MoveCharacter(float horizontal, float vertical)
    {

        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical>0)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }


    public void PlayerMovementAnimation(float horizontal, float vertical)
    {

        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1 * Mathf.Abs(horizontal);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(horizontal);

        }

        transform.localScale = scale;

        if (vertical>0)
        {
            anim.SetBool("Jump", true);
        }

        else
        {
            anim.SetBool("Jump", false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("Crouch", true);
            isCrouching = true;
        }

        else if (Input.GetKeyUp(KeyCode.C))
        {
            anim.SetBool("Crouch", false);
            isCrouching = false;
        }


        StaffAttackAnimation();

    }


    public void StaffAttackAnimation()
    {


        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("StaffAttck", true);
        }

        else
        {
            anim.SetBool("StaffAttck", false);
        }
    }

}
