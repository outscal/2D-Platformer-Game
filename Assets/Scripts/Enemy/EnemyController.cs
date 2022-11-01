using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Animator anim;
   private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<PlayerController>() != null)
        {
            
            anim.SetTrigger("EnemyAttack");
            SoundManager.Instance.Play(Sounds.EnemyAttack);
            
            PlayerController playerController = col.gameObject.GetComponent<PlayerController>();
            
            playerController.HealthSystem();
            
            
        }
    }
}