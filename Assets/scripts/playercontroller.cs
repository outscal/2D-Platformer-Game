
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Update()

    {
        float Speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(Speed));
        
        Vector3 scale = transform.localScale;
        if(Speed<0){
            scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if(Speed>0){
                scale.x=Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }
    }

