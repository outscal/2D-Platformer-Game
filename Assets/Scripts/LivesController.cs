using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject[] LivesUI;
    public Animator animator;

    public int Life;

    public void LifeReducer()
    {
        Debug.Log("Test");
        Life -= 1;

        if (Life < 5)
        {
            animator.SetBool("Enemy", true);
            Destroy(LivesUI[1].gameObject, 1);
            Debug.Log("Life reduced");
        }
        else if (Life < 4)
        {
            animator.SetBool("Enemy", true);
            Destroy(LivesUI[2], 1);
        }
        else if (Life < 3)
        {
            animator.SetBool("Enemy", true);
            Destroy(LivesUI[3], 1);
        }
        else if (Life < 2)
        {
            animator.SetBool("Enemy", true);
            Destroy(LivesUI[4], 1);
        }
        else if (Life < 1)
        {
            animator.SetBool("Enemy", true);
            Destroy(LivesUI[5], 1);
        }

    }
}
