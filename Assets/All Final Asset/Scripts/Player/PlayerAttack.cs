using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
   [SerializeField] Animator animator;
   [SerializeField] Transform attakPoint;
   [SerializeField] float attakRange = 0.5f;
   [SerializeField] LayerMask enemyLayers;
   [SerializeField] int AttackPower = 40;

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
         SoundManager.Instance.Play(Sounds.PlayerAttack);
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attakPoint.position,attakRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We Hit " + enemy.name);
            enemy.GetComponent<EnemyMovement>().TakeDamage(AttackPower);
        }
    }
    void OnDrawGizmosSeleced()
    { 
        if(attakPoint == null)
        return;
         Gizmos.DrawWireSphere(attakPoint.position,attakRange);
    }
}
