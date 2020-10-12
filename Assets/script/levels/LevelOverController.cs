using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D collider){
    if(collider.gameObject.GetComponent<PlayerControll>()!=null){
        //Debug.Log("level complted");
       LevelManager.Instance.MarkCurrentLevelComplete();
    }
}
}
