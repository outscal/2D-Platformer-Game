using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
 
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider2D coll = GetComponent<BoxCollider2D>();
        //Debug.Log(coll.size);
    }

    // Update is called once per frame
    void Update()
    {
        CrouchAction();
    }

    void CrouchAction()
    {
        BoxCollider2D coll = GetComponent<BoxCollider2D>();
        Vector2 tsize = coll.size;
        Vector2 toffset = coll.offset;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
            coll.size = new Vector2(tsize.x, 1.08907f);
            coll.offset = new Vector2(toffset.x, 0.49174f);

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
            coll.size = new Vector2(tsize.x, 2.117315f);
            coll.offset = new Vector2(toffset.x, 1.005869f);
        }
    }
}
