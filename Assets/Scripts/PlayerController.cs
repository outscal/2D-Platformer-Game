using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private float velocity;
    [SerializeField] private float jump;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayerMask;
    public int collected;
    private int health;
    [SerializeField] private GameObject canvas;
    private HealthDisplay healthDisplay;
    

    private void Start () 
    {
        health = 3;
        collected = 0;
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (canvas != null)
        {
            healthDisplay = canvas.GetComponent<HealthDisplay>();
            if (healthDisplay != null)
            {
                healthDisplay.UpdateHealthDisplay();
            }
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsCollidingWithLayer(collision, groundLayerMask) && !isGrounded)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsCollidingWithLayer(collision, groundLayerMask) && isGrounded)
        {
            isGrounded = false;
        }
    }
    private bool IsCollidingWithLayer(Collision2D collision, LayerMask layerMask)
    {
        return (layerMask.value & (1 << collision.gameObject.layer)) != 0;
    }

    private void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Animations(horizontal);
        Movement(horizontal, jump);
    }

    private void Movement (float horizontal, float jump) 
    {
        Vector3 position = transform.position;
        position.x += horizontal * velocity * Time.deltaTime;
        transform.position = position;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.y, jump));
        }
    }

    private void Animations (float horizontal) 
    {
        Animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Animator.SetTrigger(AnimationTriggers.Jumped);
        }

        transform.localScale = scale;

        if (Input.GetKeyDown("left ctrl") || Input.GetKeyDown("right ctrl"))
        {
            Animator.SetTrigger(AnimationTriggers.SomeTrigger);
            Animator.ResetTrigger(AnimationTriggers.OtherTrigger);
            Animator.SetBool(AnimationTriggers.Crouched, true);
        }
        else if (Input.GetKeyUp("left ctrl") || Input.GetKeyUp("right ctrl"))
        {
            Animator.SetTrigger(AnimationTriggers.OtherTrigger);
            Animator.ResetTrigger(AnimationTriggers.SomeTrigger);
            Animator.SetBool(AnimationTriggers.Crouched, false);
        }
    }

    public void Pickup()
    {
        collected += 1;
    }

    public void Damage()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("First");
        }

        health -= 1;
        if (healthDisplay != null)
        {
            healthDisplay.UpdateHealthDisplay();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
