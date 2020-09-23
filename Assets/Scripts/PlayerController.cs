using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public Animator animator;
        
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
        }
    }
}
