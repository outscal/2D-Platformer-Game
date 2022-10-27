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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -5f)
        {

            rb.gravityScale = Gravity;
            rb.mass = mass;
            anim.Play("Falling_Death");

            Invoke("RestartLevel", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
    private IEnumerator Scene_delay(float time)
    {
       
        yield return new WaitForSeconds(time);
      
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
