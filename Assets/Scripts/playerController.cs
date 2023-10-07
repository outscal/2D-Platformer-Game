using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator Animator;
    [SerializeField]
    float Jump_Power;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private ScoreManager Score;
    Rigidbody2D RB2d;
    public int playerHealth = 5;

    public static playerController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        RB2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Collectable_PickedUp()
    {
        Debug.Log("Collected");
        Score.Update_Score(10);
    }

    void PlayerMovement(float Horizonatal)
    {
        Vector2 pos = transform.position;
        pos.x += Horizonatal * Speed * Time.deltaTime;
        transform.position = pos;
    }
    void PlayingAnimation(float Horizonatl) {
        
        Animator.SetFloat("Speed", Mathf.Abs(Horizonatl));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetTrigger("IsJumping");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Animator.SetBool("IsCrouching", true);
        }

        Vector3 scale = transform.localScale;
        if (Horizonatl < 0) // pressed A/ right arrow 
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (Horizonatl > 0)  // pressed D/left arrow
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    public void PlayerDied()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead");
            //death anim
            UI_Manager.instance.GameOver();
        }
    }
    void Jumping() // calling as an Animation event - acc to frame
    {
        RB2d.AddForce(new Vector2(0f, Jump_Power), ForceMode2D.Force);
    }
    void StopCrouchAnim()  // calling as an Animation event - acc to frame
    {
        Animator.SetBool("IsCrouching", false);
    }

    private void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        PlayingAnimation(Horizontal);
        PlayerMovement(Horizontal);     
    }
}

        
