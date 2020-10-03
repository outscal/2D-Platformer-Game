using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<PlayerControll>()!=null){
            PlayerControll playerControll=collision.gameObject.GetComponent<PlayerControll>();
            playerControll.KillPlayer();
           
             }
         }
    }
