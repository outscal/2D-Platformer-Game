using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float Gravity;
    [SerializeField] float mass;
    [SerializeField] GameObject Game_Over_screen;
    [SerializeField] GameObject UI;
 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Game_Over_screen.SetActive(false);
        UI.SetActive(true);
       
    }


    private void FixedUpdate()
    {
        if (transform.position.y < -5f)
        {

            rb.gravityScale = Gravity;
            rb.mass = mass;
            anim.Play("Falling_Death");
            UI.SetActive(false);

            Invoke("Game_over", 2f);
           
        }
    }

    void Game_over()
    {
        Game_Over_screen.SetActive(true);
    }
}
