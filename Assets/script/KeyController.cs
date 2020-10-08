using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<PlayerControll>()!=null){
            PlayerControll playerControll=collision.gameObject.GetComponent<PlayerControll>();
            playerControll.PickKey();
            Destroy(gameObject);
        }
    }
   
}
