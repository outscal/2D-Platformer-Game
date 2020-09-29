using UnityEngine;

public class LevelController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.GetComponent<PlayerControll>()!=null){
            Debug.Log("Level completed");
        }
    }
}
