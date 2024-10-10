using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D playerCollider;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    public float crouchHeight = 0.5f;
    public float offset;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float moveSpeed = 5f;
    public float fallDamageThreshold = -10f;
    public int maxHealth = 3; // Changed to 3 hearts
    private int currentHealth;
    private float lastFallSpeed;

    private Rigidbody2D rb;
    private bool isGrounded;
    public string SceneName;

    public Image[] hearts; // UI images representing hearts
    public Sprite fullHeart; // Sprite for full heart
    public Sprite emptyHeart; // Sprite for empty heart

    public GameObject GameOverPanel;
    private Vector3 playerTransform;

    void Start()
    {
        originalColliderSize = playerCollider.size;
        originalColliderOffset = playerCollider.offset;
        playerTransform = gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHeartUI(); // Initialize heart UI
    }

    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (speed != 0)
        {
            transform.Translate(Vector3.right * speed * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", true);
            playerCollider.size = new Vector2(originalColliderSize.x, crouchHeight);
            playerCollider.offset = new Vector2(originalColliderOffset.x, offset);
        }
        else
        {
            animator.SetBool("isCrouching", false);
            playerCollider.size = originalColliderSize;
            playerCollider.offset = originalColliderOffset;
        }

        if (isGrounded && Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (!isGrounded && rb.velocity.y < 0)
        {
            lastFallSpeed = rb.velocity.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (lastFallSpeed <= fallDamageThreshold)
            {
                TakeDamage(1); // Fall damage makes the player lose 1 heart
            }
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            Invoke("SceneChanger", 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1); // Lose 1 heart when hit by an enemy
        }

        if (collision.gameObject.CompareTag("key"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("gain");
            StartCoroutine(KeyDelay(collision.gameObject));
        }
    }

    private IEnumerator KeyDelay(GameObject gameObject)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        StartCoroutine(ResetPosition());
        UpdateHeartUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(0.6f);
        gameObject.transform.position = playerTransform;
        yield return new WaitForSeconds(0.4f);
        animator.SetTrigger("reset");
    }

    private void UpdateHeartUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        GameOverPanel.SetActive(true);
        StartCoroutine(ReloadSceneAfterDelay(1f));
    }

    public void RestartGame()
    {
        ReloadCurrentScene();
        
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1;
    }

   

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //ReloadCurrentScene();
        Time.timeScale = 0;
    }

    private void SceneChanger()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ReloadCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
