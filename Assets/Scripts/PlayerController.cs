using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public Animator animator;
        public BoxCollider2D StandingCollider;
        public BoxCollider2D SittingCollider;
        bool resetCollider = false;
      
        private void FixedUpdate()
        {
            if (resetCollider)
            {
                if (!SittingCollider.enabled)
                {
                    SittingCollider.enabled = true;
                    StandingCollider.enabled = false;
                }
                else
                {
                    SittingCollider.enabled = false;
                    StandingCollider.enabled = true;
                }
                resetCollider = false;
            }
        }

        void Update()
        {
            float speed = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed",Mathf.Abs( speed));
            Vector3 scale = transform.localScale;
            if (speed < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if(speed>0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
            float jump = Input.GetAxisRaw("Vertical");
            if (jump > 0)
            {
                animator.SetBool("Jump",true);
            }
            else
            {
                animator.SetBool("Jump", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", true);
                resetCollider = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animator.SetBool("Crouch", false);
                resetCollider = true;
            }
        }
    }
}
