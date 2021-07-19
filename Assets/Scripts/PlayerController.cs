using System.Diagnostics;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        print("Game Start");
        //Debug.Log("Game Start");
    }

    // Update is called once per frame
    void Update()
    {
    
          float run = Input.GetAxisRaw("Horizontal"); // -1 to 1 
          animator.SetFloat("speed",Mathf.Abs(run));

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


    }
}
