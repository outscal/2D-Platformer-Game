
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float Jump;

    private Rigidbody2D rd2d;
    private void Awake()

    {
        rd2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()

    {
        float Speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

         MoveCharacter(Speed , vertical, GetAnimator());
         PlaymovementAnimation(Speed , vertical, GetAnimator());
        }

        private void MoveCharacter(float Speed, float vertical,Animator animator)
        {
            Vector3 position = transform.position;
            position.x += Speed*speed*Time.deltaTime;
            transform.position = position;


            if(vertical>0)
            {
                rd2d.AddForce(new Vector2(0f,Jump),ForceMode2D.Force);
            }
        }

    private Animator GetAnimator()
    {
        return animator;
    }

    private void PlaymovementAnimation(float Speed,float vertical, Animator animator)
        {
        
        animator.SetFloat("speed",Mathf.Abs(Speed));
        
        Vector3 scale = transform.localScale;
        if(Speed<0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if(Speed>0){
                scale.x=Mathf.Abs(scale.x);
            }
            transform.localScale = scale;

            Input.GetAxisRaw("vertical");
            Input.GetKeyDown(KeyCode.Space);

            if(vertical>0)
            {
            animator.SetBool("Jump", true);
            }
            else
            {
                animator.SetBool("Jump",false);
            }
        }
    }

