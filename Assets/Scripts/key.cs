using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class key : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim.SetBool("Collected", false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.SetBool("Collected", true);
            player.KeyPickUp();
            StartCoroutine(destroyer());
        }
    }

    IEnumerator destroyer()
    {
        yield return new WaitForSeconds(1);        
        Destroy(this.gameObject);
    }
}
