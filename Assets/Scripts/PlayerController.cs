    
    using System.Collections;
    using UnityEngine;
    using System;

    public class PlayerController : MonoBehaviour
        {

        public Animator animator;
        public float speed;
        public float jump;
        private Rigidbody2D rb2d;
        private bool isGrounded = false;
        public ScoreController ScoreController;
        public GameObject DeathPanel;

        public HealthManagerController healthManagerController;

    

    private void Awake()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();      
        }

    public void KillPlayer()
    {
        if(healthManagerController.healthCounter > 1)
        {
            healthManagerController.DecreaseHealth();
        }
        else
        {
            healthManagerController.DecreaseHealth();
            DeathPanel.SetActive(true);
        }
    }

    public void PickUpKey()
    {
        Debug.Log("Key is Collected");
        ScoreController.IncreaseScore(10);
    }

    // Start is called before the first frame update
    void Start()
        {
            print("Game Start");
        }

        // Update is called once per frame
        void Update()
        {

            float run = Input.GetAxisRaw("Horizontal"); // -1 to 1 0
            animator.SetFloat("speed", Mathf.Abs(run));

            float vertical = Input.GetAxisRaw("Jump");
            //crouch
            bool crouchVertical = Input.GetKey(KeyCode.LeftControl);

            MovementAnimation(run, vertical, crouchVertical);
            PlayerMovement(run, vertical);

        }

        private void FixedUpdate()
        {
            bool vertical = Input.GetKeyDown(KeyCode.Space);

            //Jump Animation & Movement

            if (vertical)

            {
                if(isGrounded)
                {
                    animator.SetBool("jump", true);
                    print("Movement: Player is on ground and can jump = " + isGrounded);

                    //rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);

                    rb2d.velocity = Vector2.up * jump;


                    isGrounded = false;
                    print("After Movement: " +
                        "Player is on ground and can jump = " + isGrounded);
                }
            }  
        }

        //Player Movement
        private void PlayerMovement(float run,float vertical)
        {
            //Run Movement
            Vector3 position = transform.localPosition;
            position.x = position.x + run * (speed * Time.deltaTime);
            transform.localPosition = position;
        }

            private void MovementAnimation(float run, float vertical, bool crouchVertical)
        {

            //Run Animation
            Vector3 scale = transform.localScale;
            // scale = x=2.0f, y=2.0f,z=1.0f
            // scale =(2.0f,2.0f,1.0f);
            if (run < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
                //scale=(scale.x,2.0f,1.0f);
                transform.localScale = scale; //transform.localScale=(scale.x,2.0f,1.0f);
            }

            else if (run > 0)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale; //transform.localScale=(scale.x,2.0f,1.0f);
            }

        
            //crouch Animation

            if (crouchVertical == true)
            {
                animator.SetBool("crouch", true);

            }
            else
            {
                animator.SetBool("crouch",false);
            }
        
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if(collision.gameObject.tag == "Platform")
            {
                isGrounded = true;
                print("Player is on ground and can jump = " + isGrounded);
                animator.SetBool("jump", false);
            }
        }
    }
