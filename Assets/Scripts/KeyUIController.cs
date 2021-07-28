using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIController : MonoBehaviour
{
    public GameObject[] KeysUI;
    public Animator animator;
    public int Key;

    public void KeyReducer()
    {
        Debug.Log("Test");
        Key -= 1;

        if (Key < 3)
        {
            //animator.SetBool("Animation", true);
            Destroy(KeysUI[0].gameObject);
        }

        if (Key < 2)
        {
            //animator.SetBool("Animation", true);
            Destroy(KeysUI[1].gameObject);
        }

        if (Key == 0)
        {
            //animator.SetBool("Animation", true);
            Destroy(KeysUI[2].gameObject);            
        }

    }
}



