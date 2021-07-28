using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    public GameObject[] LivesUI;
    public Animator animator;
    public GameOverController GameOverController;

    public int Life;

    public void LifeReducer()
    {
        Debug.Log("Test");
        Life -= 1;

        if (Life < 5)
        {
            //animator.SetBool("Enemy", true);
            Destroy(LivesUI[0].gameObject, 1);           
        }

        if (Life < 4)
        {
            //animator.SetBool("Enemy", true);
            Destroy(LivesUI[1], 1);
        }

        if (Life < 3)
        {
            //animator.SetBool("Enemy", true);
            Destroy(LivesUI[2], 1);
        }

        if (Life < 2)
        {
            //animator.SetBool("Enemy", true);
            Destroy(LivesUI[3], 1);
        }
        if (Life == 0)
        {
            //animator.SetBool("Enemy", true);
            Destroy(LivesUI[4], 1);
            GameOverController.PlayerDied();
        }

    }
}
