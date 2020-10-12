using UnityEngine;
using System.Collections;

public class LevelOverController : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D collider){
    if(collider.gameObject.GetComponent<PlayerControll>()!=null){
        //Debug.Log("level complted");
        
       StartCoroutine(LevelOver());
    }
}
public void Over(){
    gameObject.SetActive(true);
}
IEnumerator LevelOver(){
    yield return new WaitForSeconds(1);
    LevelManager.Instance.MarkCurrentLevelComplete();
}
}
