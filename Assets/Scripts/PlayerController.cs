using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator Animator;
    private bool isCrouched;
    public float speed;
    public float jump;


    public ScoreController scoreController;
    public LifeCounter lf;


    void resizeBoxColliderSize()
    {
        Vector2 Box = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        //gameObject.GetComponent<BoxCollider2D>().size = Box;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2((Box.x / 1), (Box.y / 5));

    }

    public void killPlayer()
    {
        Debug.Log("Player killed by enemy");
        lf.LoseLife();
       // Animator.SetBool("Dead", true);
       // Invoke("ReloadGame", 3f);
       // Destroy(gameObject);
       // throw new NotImplementedException();
    }

    private void ReloadGame()
    {
        SceneManager.LoadScene("S2");
    }

    public void pickUpkey()
    {
        Debug.Log("PickedUp the key");
        scoreController.IncreaseScore(10);
       // throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        lf = gameObject.GetComponent<LifeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        isCrouched = Input.GetKey(KeyCode.LeftControl);


        // Plays all Animations
        AnimationPlay(horizontal, vert);

        // Debug.Log(horizontal);

        MovementPlay(horizontal, vert);
    }

    private void MovementPlay(float horizontal, float vert)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();

        if (vert > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void AnimationPlay(float horizontal, float vert)
    {
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {

            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        Animator.SetFloat("Speed", Mathf.Abs(horizontal));



        if (vert > 0)
        {
            Animator.SetBool("Jump", true);
        }

        else  
        
            Animator.SetBool("Jump", false);
        

        
        if (isCrouched == true)
        {
            resizeBoxColliderSize();
        }

        else if (isCrouched == false)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.56f, 2.03f);
        }

        Animator.SetBool("Crouched", isCrouched);
    }
}
