using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUIController : MonoBehaviour
{
    public GameObject[] KeysUI;
    public Animator animator;

    public void KeyCollected()
    {
        animator.SetBool("Animation", true);
    }
}
